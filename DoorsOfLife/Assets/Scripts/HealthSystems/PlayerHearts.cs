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
            mainContainer = UIManager.Instance.GetHeartContainerPlayer();
        }
        base.Start();
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        if (OnDamageTaken!=null)
        {
            //UIManager.Instance.UpdateHealth(currentHealth, maxHealth);
            float t = dmg / maxHealth * 0.8f;
            CameraShake.Instance.AddTrauma(t);
            GamepadRumbler.Instance.RumbleDamaged(dmg, health,t);
            //GamepadRumbler.Instance.RumbleLinear(lowStart, lowEnd, highStart, highEnd, t / tDivisor);
            OnDamageTaken.Invoke();
        }
    }

    public override void Heal(float ammount)
    {
        base.Heal(ammount);
        if (OnHealed != null)
        {
            OnHealed.Invoke();
        }
    }

    protected override void Die()
    {
        //base.Die(); I don't want his hearts gone
        
        if (OnDeath!=null)
        {
            //GameManager.Instance.ShowGameOver();
            OnDeath.Invoke();// <-Crucial;
        }
        else
        {
            GameManager.Instance.ShowGameOver();
            //throw new NotImplementedException();
        }
    }
}
