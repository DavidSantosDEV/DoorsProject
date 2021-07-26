using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBehaviour : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    public void OnEnable()
    {
        Debug.Log("ya hear me");
        Debug.Log(anim);
        if(anim)
        anim.SetTrigger("Grow");
    }
}
