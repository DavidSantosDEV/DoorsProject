using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField]
    protected float MaxHealth;
    [SerializeField][Range(0,2)]
    protected float invencibilityTime = 1f;


    protected bool IframesOn=false;
    protected bool isDead=false;
    //[SerializeField]//[ReadOnly] //This is just for show
    [ShowOnly][SerializeField]protected float currentHealth;

    protected virtual void Start()
    {
        currentHealth = MaxHealth;
    }

    public virtual void TakeDamage(float dmgVal)
    {
        if (isDead || IframesOn) return;
        currentHealth = Mathf.Clamp(currentHealth - dmgVal, 0, MaxHealth);
        StartCoroutine(Invencible());
        if (currentHealth == 0)
        {
            Die();
        }
    }

    public virtual void Heal(float ammount)
    {
        currentHealth = Mathf.Clamp(currentHealth+ammount,0,MaxHealth);
        //OnHealthRecouped();
    }

    public void BeginInvencibilityPeriod()
    {
        IframesOn = true;
        Invoke(nameof(EndInvencibilityPeriod), invencibilityTime);
    }

    public void EndInvencibilityPeriod()
    {
        IframesOn = false;
    }

    /*private IEnumerator RecoverLifeOverTime()
    {
        while (true)
        {
            Heal(1);
            yield return new WaitForSeconds(0.1f);
            //OnHealthRecouped();
        }
        
    }

    protected virtual void OnHealthRecouped()
    {
        Debug.Log("Health recovered");
    }*/

    protected IEnumerator Invencible()
    {
        IframesOn = true;
        yield return new WaitForSeconds(invencibilityTime);
        IframesOn = false;
    }

    protected virtual void Die()
    {
        isDead = true;
    }

    public void DestroyTheParent()
    {
        Destroy(gameObject);
    }
}
