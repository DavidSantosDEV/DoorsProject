using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviourBloob : StateMachineBehaviour
{
    EnemyBloob parent;
    private void ParentCheck(Animator animator)
    {
        if (parent == null)
        {
            parent = animator.GetComponent<EnemyBloob>();
        }
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ParentCheck(animator);
        if (!parent.IsDead)
        {
            parent.SetInvincible();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ParentCheck(animator);
        if (!parent.IsDead)
        {
            parent.SetVulnerable();
            parent.ReturnToChasing();
        }  
    }
}
