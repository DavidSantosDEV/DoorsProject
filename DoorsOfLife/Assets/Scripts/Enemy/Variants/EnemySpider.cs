using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class EnemySpider : EnemyScript
{
    [Header("Eye Light")]
    [SerializeField]
    private Light2D eyelight;

    public void ShutEye()
    {
        eyelight.enabled=false;
    }

    public void OpenEye()
    {
        eyelight.enabled=true;
    }

    public override void MeleeDamage()
    {
        base.MeleeDamage();

        attackPoint.localPosition = directionForAttack * meleeAttackRange;
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, meleePointWidth, enemyHitLayer);
        if (hit /*&& hit.CompareTag("Player")*/)
        {
            player.PlayerHeartsComponent.TakeDamage(damagetoGive);
            //GameManager.Instance.GetPlayer().PlayerHeartsComponent.TakeDamage(damagetoGive);
            //PlayerController.Instance.playerHealthComponent.TakeDamage(damagetoGive);
            Debug.Log("Damage given to player: " + damagetoGive);
            
        }
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, meleePointWidth);
    }
}
