using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class EnemyBloob : EnemyScript
{
    /*[Header("Blob Attack Extra Settings")]
    [SerializeField]
    private Vector2 attackpoint2;*/
    [SerializeField]
    private float extraRange;

    private SortingGroup sGroup;
    private int sortOriginal;

    private float width = 1;
    private float height = 1;

    private void Start()
    {
        sGroup =GetComponentInParent<SortingGroup>();
        sortOriginal = sGroup.sortingOrder;
    }

    public override void MeleeDamage()
    {
        base.MeleeDamage();
        //Collider2D[] hits= new Collider2D[1];
        
        if (Mathf.Abs(directionForAttack.x) > Mathf.Abs(directionForAttack.y))
        {
            //Right and Left
            width = meleeAttackRange;
            height = meleePointWidth;
            attackPoint.localPosition = directionForAttack * extraRange;
        }
        else
        {
            height = meleeAttackRange;
            width = meleePointWidth;
            //Up and Down
            attackPoint.localPosition = directionForAttack;

        }
        Collider2D hit = Physics2D.OverlapBox(attackPoint.position, new Vector2(width, height), 0, enemyHitLayer);
        if (hit)
        {
            PlayerController.Instance.playerHealthComponent.TakeDamage(damagetoGive);
        }
    }

    protected override void Attack()
    {
        StopMovement();
        //state = EnemyState.Attacking;
        directionForAttack = PlayerController.Instance.transform.position - transform.position;
        if (Mathf.Abs(directionForAttack.x) > Mathf.Abs(directionForAttack.y))
        {
            if (directionForAttack.x > 0)
            {
                directionForAttack = -Vector2.left;
            }
            else
            {
                directionForAttack = Vector2.left;
            }
        }
        else
        {
            if (directionForAttack.y > 0)
            {
                directionForAttack = Vector2.up;
            }
            else
            {
                directionForAttack = -Vector2.up;
            }
        }
        //Do a check if it'll hit a collider, if yes and its not the player then don't attack I guess

        enemyAnimation.PlayAttackMeleeAnimation(directionForAttack);

        canAttack = false;
        Invoke(nameof(ResetAttack), timeBetweenAttack);
        Debug.Log("bloob Attack");
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        
        Gizmos.DrawWireCube(attackPoint.position, new Vector2(width, height/*meleePointWidth*/));
    }

    public void SetInvincible()
    {
        enemyHealth.InvicibilitySet(true);
    }

    public void SetVulnerable()
    {
        enemyHealth.InvicibilitySet(false);
    }

    public void SetSortingUp()
    {
        sGroup.sortingOrder=sortOriginal+1;
    }

    public void SetSortingDown()
    {
        sGroup.sortingOrder=sortOriginal-1;
    }

    public void SetSortingOriginal()
    {
        sGroup.sortingOrder = sortOriginal;
    }
}
