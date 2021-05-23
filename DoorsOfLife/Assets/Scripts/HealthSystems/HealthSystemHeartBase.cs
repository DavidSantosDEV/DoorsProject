using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthSystemHeartBase : MonoBehaviour //TODO GET A VERTICAL ALIGNER TO THE CONTAINERS AND THEN GO AHEAD AND ADD THEM, WITH A MAX HEARTS PER LINE
{
    [Header("Heart Settings")]
    [SerializeField]
    private GameObject HeartContainer;
    [SerializeField]
    private GameObject prefabHeart=null;
    [SerializeField]
    Sprite heartEmpty;
    [SerializeField]
    Sprite heartFull;
    List<Image> hearts = new List<Image>();

    
    [Header("Health Settings Base")]
    [SerializeField][Range(0,20)]
    private int maxHealth=10;
    [SerializeField][ShowOnly]
    private int health;
    [SerializeField][ShowOnly]
    private bool isDead=false;

    private void Awake()
    {
        health = maxHealth;
        CreateHearts(maxHealth);
    }

    private void CreateHearts(int val)
    {
        Debug.Log("Working: ");
        for(int i=0; i<val; i++)
        {
            GameObject h = Instantiate(prefabHeart, HeartContainer.transform);
            hearts.Add(h.GetComponent<Image>());
        }
    }


    public virtual void TakeDamage(int dmg)
    {
        if (isDead) return;
    
        health = Mathf.Clamp(health - dmg,0,maxHealth);
        UpdateHearts();
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Heal(int ammount)
    {
        if (health >= maxHealth)
        {
            return;
        }
        health = Mathf.Clamp(health+ammount,0,maxHealth);
        UpdateHearts();
    }

    protected void UpdateHearts()
    {
        int heartFill = health;
        foreach (Image i in hearts)
        {
            if (heartFill <= 0)
            {
                i.sprite = heartEmpty;
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
        health = maxHealth;
        CreateHearts(val);
        UpdateHearts();
    }

    protected virtual void Die()
    {
        HeartContainer.SetActive(false);
    }

}
