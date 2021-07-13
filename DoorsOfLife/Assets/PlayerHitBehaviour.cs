using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBehaviour : StateMachineBehaviour
{
    private PlayerHearts hearts;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (hearts==null)
        {
            if (GameManager.Instance)
            {
                hearts = GameManager.Instance.GetPlayer().PlayerHeartsComponent;
            }
            else
            {
                hearts = animator.GetComponent<PlayerHearts>();
                if (hearts == null)
                {
                    hearts = animator.GetComponentInChildren<PlayerHearts>();
                }
            }
        }
        hearts?.InvicibilitySet(true);
        UIManager.Instance?.UpdatePortraitPain();
    //    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hearts?.InvicibilitySet(false);
        UIManager.Instance?.UpdatePortraitNormal();
    //    
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
