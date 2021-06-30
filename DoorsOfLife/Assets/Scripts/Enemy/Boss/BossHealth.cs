using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : HeartSystemBase
{
    // Start is called before the first frame update
    BossBehaviour parent;

    [SerializeField]
    float healthdivSecondPhase;
    bool FlagHalfHealth = false;

    protected override void Start()
    {
        parent = GetComponent<BossBehaviour>();
    }
    protected override void Die()
    {
        base.Die();
        parent.OnDeath();
    }

    public override void TakeDamage(float dmgVal)
    {
        base.TakeDamage(dmgVal);
        if ((health <= maxHealth / healthdivSecondPhase) && !FlagHalfHealth)
        {
            parent.SetSecondPhaseBehaviour();
            FlagHalfHealth = true;
        }
    }
}
