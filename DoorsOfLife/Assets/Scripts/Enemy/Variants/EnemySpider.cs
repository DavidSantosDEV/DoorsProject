using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class EnemySpider : EnemyScript
{
    [Header("Eye Light")]
    [SerializeField]
    private Light2D eyelight;
    [SerializeField]
    private float desiredeyeIntensityClosed=0;
    private float originalIntensity;

    public void ShutEye()
    {
        eyelight.intensity = desiredeyeIntensityClosed;
    }

    public void OpenEye()
    {
        eyelight.intensity = originalIntensity;
    }

    private void Start()
    {
        originalIntensity = eyelight.intensity;
    }

    public override void MeleeDamage()
    {
        base.MeleeDamage();

        attackPoint.localPosition = directionForAttack * meleeAttackRange;
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, meleePointWidth, enemyHitLayer);
        if (hit /*&& hit.CompareTag("Player")*/)
        {
            GameManager.Instance.GetPlayer().PlayerHealthComponent.TakeDamage(damagetoGive);
            //PlayerController.Instance.playerHealthComponent.TakeDamage(damagetoGive);
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
