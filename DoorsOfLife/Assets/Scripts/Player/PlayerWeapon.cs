using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    //Angle to vector 2 = (Vector2)(Quaternion.Euler(0, 0, aimAngle) * Vector2.right)

    public enum AttackState
    {
        Idle,
        Preparing, //May be useless, probably deleting preparing state
        Attacking,
        WaitFollow
    }



    [Header("Melee Weapon Settings")]
    [SerializeField]
    private float damage=20f;
    [SerializeField][Range(0,3)]
    private float meleeWidth = 2f;
    [SerializeField][Range(0.5f,2f)]
    private float meleeRange = 1;
    /*[SerializeField][Range(1,2)]
    private float damageMultiplier=1.1f;*/
    //private AttackState currentAttackState=AttackState.Idle;
    //private ushort currentAttackChain = 0;
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private LayerMask weaponHitLayers;

    private Vector2 currentAttackDirection;

    // Start is called before the first frame update
    void Start()
    {
        if (!attackPoint) attackPoint = transform;
    }

    //Melee -----------------------------------------------------------
    /*public void ChangeAttackState(AttackState state)
    {
        currentAttackState = state;
    }*/

    public void PlayerAttack(Vector2 AttackDirection)
    {
        currentAttackDirection = AttackDirection;
        attackPoint.localPosition = AttackDirection * meleeRange;

        //Debug.Log(attackPoint.localPosition);

        //switch (currentAttackState)
        //{
          //  case AttackState.Idle:
            //    ResetAttack();
              //  doAttack(currentAttackChain);
                //break;
            //case AttackState.WaitFollow:
              //  currentAttackChain++;
                //doAttack(currentAttackChain);
                //break;
        
    }

    /*private void ResetAttack()
    {
        currentAttackChain = 0;
    }*/

    private void doAttack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, meleeWidth, weaponHitLayers);
        foreach(Collider2D hit in hits)
        {
            if (hit.gameObject.CompareTag("Enemy")){
                HeartSystemBase enemyHealth = hit.gameObject.GetComponent<HeartSystemBase>();
                enemyHealth.TakeDamage(damage);
            }
        }
    }

    public Vector2 ReturnAttackDirMove()
    {
        return new Vector2(Mathf.RoundToInt(currentAttackDirection.x), Mathf.RoundToInt(currentAttackDirection.y));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, meleeWidth);
    }

}
