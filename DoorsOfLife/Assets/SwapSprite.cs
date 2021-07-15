using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapSprite : MonoBehaviour
{
    [SerializeField]
    private Sprite swap;

    private SpriteRenderer r;
    private void Awake()
    {
        r = GetComponent<SpriteRenderer>();
    }
    public void Swap()
    {
        r.sprite = swap;
    }
}
