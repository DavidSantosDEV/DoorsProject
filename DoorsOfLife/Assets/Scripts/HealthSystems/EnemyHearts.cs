using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHearts : HeartSystemBase
{
    EnemyScript _parent;
    EnemyAnimator _animator;

    public void SettupComponent(EnemyScript enemy, EnemyAnimator parentAnimator)
    {
        _parent = enemy;
        _animator = parentAnimator;
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        if (isDead || isInvincible) return;
        _animator.PlayHitAnimation();
        _parent.SetStunned();
    }

    protected override void Die()
    {
        base.Die();
        _animator.PlayDeathAnimation();
        _parent.OnEnemyDied();
    }

}
