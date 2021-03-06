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
        int rnd = Random.Range(25, (25*randomList.Length));
        rnd = Mathf.RoundToInt( (25 * randomList.Length) / rnd);
        myRenderer.sprite = randomList[rnd];
    }
}
