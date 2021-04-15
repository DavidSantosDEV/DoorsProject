using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthComponent
{

    EnemyScript enemyParent;
    EnemyAnimator _animator;

    public void SettupComponent(EnemyScript parent, EnemyAnimator parentAnimator)
    {
        enemyParent = parent;
        _animator = parentAnimator;
    }

    /*protected override void Start()
    {
        base.Start();
        //_animator = GetComponent<EnemyAnimator>();
    }*/

    public override void TakeDamage(float dmgVal)
    {
        base.TakeDamage(dmgVal);
        if (isDead) return;
        PlayHitAnimation();
        //enemyParent.SetStunned();
    }

    protected override void Die()
    {
        base.Die();
        PlayDeathAnimation();
        enemyParent.OnEnemyDied();
    }



    private void PlayHitAnimation()
    {
        _animator.PlayHitAnimation();
    }

    private void PlayDeathAnimation()
    {
        _animator.PlayDeathAnimation();
    }

    public void InvicibilitySet(bool set)
    {
        IframesOn = set;
    }
}
