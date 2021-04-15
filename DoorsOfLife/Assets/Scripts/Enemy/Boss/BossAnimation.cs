using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _mainAnimator, _headAnimator;

    private string armAttackAnim = "ArmAttack";
    // Start is called before the first frame update


    public void PlayAttackAnimation(int arm)
    {
        _mainAnimator.SetTrigger(armAttackAnim + arm); //The idea is that way we only have one function
    }

    public void PlayHeadAttack()
    {

    }
}
