using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomFlower : MonoBehaviour
{
    [SerializeField]
    private Sprite[] randomList;

    private SpriteRenderer myRenderer;
    private void Awake()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        myRenderer.sprite = randomList[Random.Range(0, randomList.Length - 1)];
    }
}
