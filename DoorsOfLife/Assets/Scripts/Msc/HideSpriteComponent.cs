using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpriteComponent : MonoBehaviour
{
    SpriteRenderer mySprite;

    //Color spriteColor;

    [SerializeField]
    float alphaVal = 0.2f;
    [SerializeField]
    float speed=20;

    private void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();
        //spriteColor = mySprite.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopAllCoroutines();
        StartCoroutine(BeginAlphaLow());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopAllCoroutines();
        StartCoroutine(BeginAlphaHigh());
    }

    private IEnumerator BeginAlphaLow()
    {
        while (mySprite.color.a > alphaVal)
        {
            mySprite.color = new Color (mySprite.color.r, mySprite.color.g, mySprite.color.b, Mathf.Lerp(mySprite.color.a, alphaVal, Time.deltaTime));
            yield return new WaitForSeconds(1 / speed);
        }
        
    }

    private IEnumerator BeginAlphaHigh()
    {
        while(mySprite.color.a < 1)
        {
            mySprite.color = new Color(mySprite.color.r, mySprite.color.g, mySprite.color.b, Mathf.Lerp(mySprite.color.a, 1, Time.deltaTime));
            yield return new WaitForSeconds(1 / (speed*2));
        }
        
    }
}
