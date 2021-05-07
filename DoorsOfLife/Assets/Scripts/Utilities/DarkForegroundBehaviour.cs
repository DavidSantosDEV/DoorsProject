using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class DarkForegroundBehaviour : MonoBehaviour
{
    Tilemap tile;

    [SerializeField]
    float Speed = 2;//5e-05f;

    Color originalCol;
    //private float alphaValueDesired = 0;

    private void Awake()
    {
        tile = GetComponent<Tilemap>();
        originalCol = tile.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        StartCoroutine(nameof(InvisibleStart));
    }

    IEnumerator InvisibleStart()
    {
        while(tile.color.a!=0)
        {
            tile.color =new Color(tile.color.r,tile.color.g,tile.color.a, Mathf.Clamp(tile.color.a-(Time.deltaTime*Speed),0,originalCol.a));
            yield return new WaitForEndOfFrame();//WaitForSeconds(0.01f);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        StopCoroutine(nameof(InvisibleStart));
        tile.color = originalCol;
    }
}
