using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    public UnityEvent onFountainActivate;
    public UnityEvent onAnimationComplete;

    private Animator anim;

    private bool isWatering = false;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
    }

    public void StartWatering()
    {
        if (!isWatering)
        {
            anim.SetTrigger("Blossom");
            isWatering = true;
            onFountainActivate.Invoke();
        }
    }

    public void AnimationComplete()
    {
        onAnimationComplete.Invoke();
    }
}
