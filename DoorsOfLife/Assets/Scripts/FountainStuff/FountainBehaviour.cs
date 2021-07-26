using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainBehaviour : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Watered", true);
        animator.GetComponent<Fountain>().AnimationComplete();
    }
}
