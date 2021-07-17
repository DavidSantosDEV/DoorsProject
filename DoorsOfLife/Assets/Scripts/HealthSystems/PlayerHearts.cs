using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHearts : HeartSystemBase
{
    public event Action OnHealed;
    public event Action OnDamageTaken;
    public event Action OnDeath;

    protected override void Start()
    {
        if (mainContainer == null)
        {
            mainContainer = UIManager.Instance?.GetHeartContainerPlayer();
            List<GameObject> children = new List<GameObject>();
            if (mainContainer)
            {
                foreach (Transform child in mainContainer.transform) children.Add(child.gameObject);
                children.ForEach(child => Destroy(child));
            }
        }
        CreateHearts(maxHealth);
        UpdateHearts();
        //base.Start();
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        if (isDead || isInvincible) return;
        if (OnDamageTaken!=null)
        {
            //UIManager.Instance.UpdateHealth(currentHealth, maxHealth);
            float t = dmg / maxHealth * 0.8f;
            CameraShake.Instance.AddTrauma(t);
            GamepadRumbler.Instance.RumbleDamaged(dmg, health,t);
            //GamepadRumbler.Instance.RumbleLinear(lowStart, lowEnd, highStart, highEnd, t / tDivisor);
            OnDamageTaken.Invoke(); 
        }
        UpdateGameManagerHearts();
    }

    public override void Heal(float ammount)
    {
        base.Heal(ammount);
        if (OnHealed != null)
        {
            OnHealed.Invoke();
        }
        UpdateGameManagerHearts();
    }

    protected override void Die()
    {
        base.Die();
        OnDeath.Invoke();// <-Crucial;
    }

    public void SetHealth(float newVal)
    {
        health = newVal;
    }

    private void UpdateGameManagerHearts()
    {
        GameManager.Instance?.UpdatePlayerHealth(health);
    }
    public void ResetComponent()
    {
        mainContainer.gameObject.SetActive(true);
        isDead = false;
        health = maxHealth;
        UpdateHearts();
    }
}
