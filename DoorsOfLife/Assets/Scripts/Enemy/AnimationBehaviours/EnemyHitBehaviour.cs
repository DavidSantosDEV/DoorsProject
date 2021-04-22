using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBehaviour : StateMachineBehaviour
{
    EnemyScript parent;

    private void ParentCheck(Animator animator)
    {
        if (parent == null)
        {
            parent = animator.GetComponent<EnemyScript>();
        }
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ParentCheck(animator);
        parent.SetStunned();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //ParentCheck(animator);
        parent.ResetStunned();
    }

    
}
