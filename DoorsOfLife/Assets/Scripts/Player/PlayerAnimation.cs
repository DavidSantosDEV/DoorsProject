using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator playerAnimator;

    //Animation String IDs

    private int playerMovementHorizontalID;
    private int playerMovementVerticalID;
    private int playerSpeedAnimationID;
    private int playerAttackAnimationID;
    private int playerDeathAnimationID;
    //private int playerAimAnimationID;
    private int playerHitAnimationID;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();

        //Setting animation IDs
        playerMovementHorizontalID = Animator.StringToHash("Horizontal");
        playerMovementVerticalID = Animator.StringToHash("Vertical");
        playerSpeedAnimationID = Animator.StringToHash("Speed");
        playerAttackAnimationID = Animator.StringToHash("Attack");
        playerDeathAnimationID = Animator.StringToHash("Death");
        //playerAimAnimationID = Animator.StringToHash("Aiming");
        playerHitAnimationID = Animator.StringToHash("Hit");
    }



    public void UpdateMovementAnimation(Vector2 movement /*float Horizontal,float Vertical,float Speed*/)
    {
        if(movement != Vector2.zero)
        {
            playerAnimator.SetFloat(playerMovementHorizontalID, movement.x);//Horizontal);
            playerAnimator.SetFloat(playerMovementVerticalID, movement.y);// Vertical);
        }
        playerAnimator.SetFloat(playerSpeedAnimationID, movement.magnitude);//Speed);
    }

    public void UpdateMovementSpeed(float speed)
    {
        playerAnimator.SetFloat(playerSpeedAnimationID, speed);
    }

    public void PlayHitAnimation()
    {
        playerAnimator.SetTrigger(playerHitAnimationID);
        //playerAnimator.ResetTrigger(playerHitAnimationID);
    }

    public void PlayDeathAnimation()
    {
        playerAnimator.SetTrigger(playerDeathAnimationID);
    }

    public void PlayAttackAnimation()
    {
        playerAnimator.SetTrigger(playerAttackAnimationID);
    }

    public void PlayInteractionAnimation(InteractionType interaction, Vector2 currentDirection)
    {
        switch (interaction)
        {
            case InteractionType.DialogInteraction:
                PlayDialogAnimation(); //May or may not be deleted
                break;
            case InteractionType.ItemPickup:
                PlayPickupAnimation();
                break;
            case InteractionType.ItemTouch:
                PlayTouchAnimation();
                break;
        }
    }

    private void PlayPickupAnimation()
    {

    }

    private void PlayTouchAnimation()
    {

    }

    private void PlayDialogAnimation()
    {

    }
}
