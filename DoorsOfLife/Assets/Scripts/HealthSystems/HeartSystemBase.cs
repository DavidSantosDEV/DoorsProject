using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeartSystemBase : MonoBehaviour //TODO GET A VERTICAL ALIGNER TO THE CONTAINERS AND THEN GO AHEAD AND ADD THEM, WITH A MAX HEARTS PER LINE
{
    [Header("Heart Image Settings")]
    [SerializeField]
    protected VerticalLayoutGroup mainContainer;
    [SerializeField]
    protected GameObject prefabHeart=null;
    [SerializeField]
    protected GameObject heartContainerPrefab;
    [SerializeField]
    protected int maxHeartsRow = 10;
    [SerializeField]
    protected Sprite heartEmpty;
    [SerializeField]
    protected Sprite heartHalf;
    [SerializeField]
    protected Sprite heartFull;

    protected List<Image> hearts = new List<Image>();

    [Header("Health Settings Base")]
    [SerializeField][Range(0,40)]
    protected int maxHealth=10;
    [SerializeField][ShowOnly]
    protected bool isDead=false;
    [SerializeField][ShowOnly]
    protected bool isInvincible=false;

    [SerializeField][ShowOnly]
    private float _health;

    public int MaxHealth => maxHealth;

    public bool IsDead => isDead;

    protected float health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = Mathf.Round(value * 2) / 2;
            UpdateHearts();
        }
    }

    //Aux variables
    private List<GameObject> heartContainers = new List<GameObject>();
    private int rowIndex = 0;
    private int lineIndex = 0;

    protected virtual void Start()
    {
        _health = maxHealth;
        CreateHearts(maxHealth);
    }

    protected void CreateHearts(int val)
    {
        if (GameManager.Instance == null) return;
        Debug.Log("Working: ");
        
        if (rowIndex == 0)
        {
            heartContainers.Add(ContainerCreator());
        }   
        for (int i = 0; i < val; i++)
        {
            GameObject h = Instantiate(prefabHeart, heartContainers[rowIndex].transform);
            hearts.Add(h.GetComponent<Image>());
            lineIndex++;
            if (lineIndex == maxHeartsRow)
            {
                rowIndex++;
                mainContainer.spacing = 0.02f * (rowIndex + 1);
                heartContainers.Add(ContainerCreator());
                lineIndex = 0;
            }
        }
    }

    private GameObject ContainerCreator()
    {
        Debug.Log(this.gameObject);
        GameObject container = Instantiate(heartContainerPrefab, mainContainer.gameObject.transform);
        return container;
    }


    public virtual void TakeDamage(float dmg)
    {
        if (isDead || isInvincible) return;
    
        health = Mathf.Clamp(health - dmg,0,maxHealth);
        UpdateHearts();
        if (_health <= 0)
        {
            Die();
        }
    }

    public virtual void Heal(float ammount)
    {
        if (_health >= maxHealth)
        {
            return;
        }
        health = Mathf.Clamp(health+ammount,0,maxHealth);
        UpdateHearts();
    }

    public virtual void HealFull()
    {
        health = maxHealth;
        UpdateHearts();
    }


    protected void UpdateHearts()
    {
        float heartFill = _health;
        foreach (Image i in hearts)
        {
            if (heartFill <= 0)
            {
                i.sprite = heartEmpty;
            }
            else if(heartFill == 0.5f)
            {
                i.sprite = heartHalf;
            }
            else
            {
                i.sprite = heartFull;
            }
            heartFill -= 1;
        }

    }

    public void UpgradeHealth(int val)
    {
        maxHealth+=val;
        _health = maxHealth;
        CreateHearts(val);
        UpdateHearts();
    }

    public void InvicibilitySet(bool set)
    {
        isInvincible = set;
    }

    protected virtual void Die()
    {
        isDead = true;
        if(mainContainer)
        mainContainer.gameObject.SetActive(false);
    }

}
/*private void CreateHearts(int val)
{
    Debug.Log("Working: ");
    for(int i=0; i<val; i++)
    {
        GameObject h = Instantiate(prefabHeart, HeartContainer.gameObject.transform);
        hearts.Add(h.GetComponent<Image>());
    }
}*/