using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleter : MonoBehaviour
{
    [SerializeField]
    private InteractDialogue dialogue;
    [SerializeField]
    Collider2D col;

    private void Awake()
    {
        dialogue.OnInteractionStopped += DeleteCol;
    }

    private void DeleteCol()
    {
        Destroy(col);
    }
}
