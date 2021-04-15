using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpider : EnemyScript
{
    public override void MeleeDamage()
    {
        base.MeleeDamage();

        attackPoint.localPosition = directionForAttack * meleeAttackRange;
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, meleePointWidth, enemyHitLayer);
        if (hit && hit.CompareTag("Player"))
        {
            PlayerController.Instance.playerHealthComponent.TakeDamage(damagetoGive);
            Debug.Log("Damage given to player: " + damagetoGive);
            
        }
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackRange);
    }
}
