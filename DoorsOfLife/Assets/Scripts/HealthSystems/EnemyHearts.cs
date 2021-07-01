using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHearts : HeartSystemBase
{
    EnemyScript _parent;
    EnemyAnimator _animator;

    [SerializeField]
    private Transform[] bonkPoint;
    [SerializeField]
    private GameObject prefabBonk;
    public void SettupComponent(EnemyScript enemy, EnemyAnimator parentAnimator)
    {
        _parent = enemy;
        _animator = parentAnimator;
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        
        if (isDead || isInvincible) return;
        SpawnRandomBonk();
        _animator.PlayHitAnimation();
        _parent.SetStunned();
    }

    protected override void Die()
    {
        base.Die();
        _animator.PlayDeathAnimation();
        _parent.OnEnemyDied();
    }


    private void SpawnRandomBonk()
    {
        if (prefabBonk)
        {
            if (bonkPoint.Length > 0)
            {
                int chosen = Random.Range(0, (bonkPoint.Length));
                GameObject bonk = PoolManager.Instance?.SpawnObject(prefabBonk);
                if (bonk)
                {
                    bonk.transform.position = bonkPoint[chosen].position;
                    bonk.transform.rotation = bonkPoint[chosen].rotation;
                }
                else
                {
                    Instantiate(prefabBonk, bonkPoint[chosen].position, bonkPoint[chosen].rotation);
                }
                
            }
        }
    }
}
