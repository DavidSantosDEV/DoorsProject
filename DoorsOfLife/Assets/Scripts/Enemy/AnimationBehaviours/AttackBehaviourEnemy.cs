using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviourEnemy : StateMachineBehaviour
{

    EnemyScript parent;

    private void ParentCheck(Animator animator)
    {
        if (parent == null)
        {
            parent = animator.GetComponent<EnemyScript>();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ParentCheck(animator);
        if (!parent.IsDead)
        {
            parent.ReturnToChasing();
        }
    }

}
