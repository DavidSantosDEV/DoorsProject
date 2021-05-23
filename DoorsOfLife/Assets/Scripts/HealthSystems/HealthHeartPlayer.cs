using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeartPlayer : HealthSystemHeartBase
{
    public event Action OnHealed;
    public event Action OnDamageTaken;
    public event Action OnDeath;

    public override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
    }

    public override void Heal(int ammount)
    {
        base.Heal(ammount);
    }

    protected override void Die()
    {
        base.Die();
        if (OnDeath!=null)
        {
            OnDeath();
        }
    }
}
