using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWhenOverlay : MonoBehaviour
{

    public SpriteRenderer[] spriteRenderer;
    bool bfade = false;
    [SerializeField][Range(0,1)]
    private float minAlphaAmmount;
    // Start is called before the first frame update
    private void Start()
    {
        enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerFeet"))
        {
            bfade = true;
            enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerFeet"))
        {
            //spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 255);
            enabled = true;
            bfade = false;
        }

    }

    private void Update()
    {
        if (bfade)
        {
            float currentAlpha = spriteRenderer[0].color.a;
            currentAlpha -= 1 * Time.deltaTime;
            foreach(SpriteRenderer spt in spriteRenderer)
            {
                spt.color = new Color(spt.color.r, spt.color.g, spt.color.b, currentAlpha);

            }
            if (currentAlpha <= minAlphaAmmount)
            {
                enabled = false;
            }
        }
        else
        {
            float currentAlpha = spriteRenderer[0].color.a;
            currentAlpha += 1 * Time.deltaTime;
            foreach (SpriteRenderer spt in spriteRenderer)
            {
                spt.color = new Color(spt.color.r, spt.color.g, spt.color.b, currentAlpha);

            }
            if (currentAlpha >= 1)
            {
                enabled = false;
            }
        }
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }
    
}
