using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorImage : MonoBehaviour
{
    [SerializeField]
    private GameObject container;
    [SerializeField]
    private float offsetX;

    void Start()
    {
        Transform childcont = container.transform.GetChild(container.transform.childCount - 1);
        Transform lastHeart = childcont.GetChild(childcont.childCount - 1);
        Debug.Log(lastHeart.gameObject);
        transform.position = new Vector2(lastHeart.position.x - offsetX,transform.position.y);
    }

    private void Update()
    {
        Transform childcont = container.transform.GetChild(container.transform.childCount - 2);
        Transform lastHeart = childcont.GetChild(childcont.childCount - 1);
        Debug.Log(lastHeart.gameObject);
        transform.position = new Vector2(lastHeart.position.x - offsetX, transform.position.y);
    }
}
