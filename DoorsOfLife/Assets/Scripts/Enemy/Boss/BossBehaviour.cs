using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossBehaviour : MonoBehaviour
{
    [SerializeField]
    private BossHeadBehaviour myHead;

    private BossAnimation bossAnimation=null;
    public BoxCollider2D[] armCols;

    bool canAttack = false;
    bool isActive = false;

    [Header("Attack")]
    [SerializeField]
    float waitAttackTime = 4;
    [SerializeField]
    float offsetAttackTime=0.3f;
    [SerializeField]
    BossZonesBehaviour[] bossAttackZones;
    

    private void Start()
    {
        DisableArmColliders();
        bossAnimation = GetComponent<BossAnimation>();
    }

    public void ActivateBoss()
    {
        isActive = true;
        StartCoroutine(nameof(AttackRoutine));
    }

    IEnumerator AttackRoutine()
    {
        while (isActive)
        {
            if (canAttack)
            {
                Attack();
            }
            yield return new WaitForSeconds(waitAttackTime - Random.Range(0, offsetAttackTime));
        }
    }

    private void Attack()
    {
        bossAnimation.PlayAttackAnimation(Mathf.RoundToInt(Random.Range(1, 10)));
    }

    void DisableArmColliders()
    {
        for(int i = 0; i < armCols.Length; i++)
        {
            armCols[i].enabled = false;
        }
    }

    void ActivateArmCol(int arm)
    {
        armCols[arm].enabled = true;
    }

    public void OnDeath()
    {
        isActive = false;
    }

    public void SetSecondPhaseBehaviour()
    {

    }

    public void DoArmAttack()
    {

    }
    
    //Attack


}
