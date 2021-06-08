using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    [SerializeField]
    private float upAmmount=2;
    [SerializeField]
    private float val;
    [SerializeField]
    private float speed=1;
    // Start is called before the first frame update

    Vector2 originalPos;
    Vector2 target;

    bool flag=false;

    private void Awake()
    {
        originalPos = transform.position;
        
    }


    private void FixedUpdate()
    {
        target = new Vector2(originalPos.x, originalPos.y + upAmmount);
        if (flag)
        {
            transform.position = Vector2.Lerp(transform.position, target, Time.deltaTime*speed);
            flag = Vector2.Distance(transform.position, target)>val;
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, originalPos, Time.deltaTime*speed);
            flag = Vector2.Distance(transform.position, originalPos) < val;
        }
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }
}

