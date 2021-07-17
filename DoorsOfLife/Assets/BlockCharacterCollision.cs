using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCharacterCollision : MonoBehaviour
{
    [SerializeField]
    private Collider2D mainCol;
    [SerializeField]
    private Collider2D blockerCol;
    private void Start()
    {
        Physics2D.IgnoreCollision(mainCol, blockerCol, true);
    }

}
