using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{

    private Animator myAnimator;


    private int movementHorizontalID;
    private int movementVerticalID;
    private int movementSpeedID;

    private int deathID;
    private int hitID;
    private int vanishID;

    private int attackmeleeID;
    private int attackDirectionHorizontalID;
    private int attackDirectionVerticalID;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        movementHorizontalID = Animator.StringToHash("Horizontal");
        movementVerticalID = Animator.StringToHash("Vertical");
        movementSpeedID = Animator.StringToHash("Speed");

        hitID = Animator.StringToHash("Hit");
        deathID = Animator.StringToHash("Die");
        vanishID = Animator.StringToHash("Vanish");

        attackmeleeID=Animator.StringToHash("AttackMelee");
        attackDirectionHorizontalID=Animator.StringToHash("AttackHorizontal");
        attackDirectionVerticalID=Animator.StringToHash("AttackVertical");
}

    public void UpdateMovementAnimation(Vector2 movement)
    {
        myAnimator.SetFloat(movementHorizontalID, movement.x);
        myAnimator.SetFloat(movementVerticalID, movement.y);
        myAnimator.SetFloat(movementSpeedID, movement.magnitude);
    }

    public void PlayHitAnimation()
    {
        myAnimator.SetTrigger(hitID);
    }

    public void PlayAttackMeleeAnimation(Vector2 direction)
    {
        myAnimator.SetFloat(attackDirectionHorizontalID, direction.x);
        myAnimator.SetFloat(attackDirectionVerticalID, direction.y);
        myAnimator.SetTrigger(attackmeleeID);
    }

    public void PlayDeathAnimation()
    {
        myAnimator.SetTrigger(deathID);
    }

    public void PlayVanishAnimation()
    {
        myAnimator.SetTrigger(vanishID);
    }
}
