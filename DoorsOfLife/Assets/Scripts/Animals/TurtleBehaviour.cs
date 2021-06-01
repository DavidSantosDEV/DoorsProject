using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleBehaviour : MonoBehaviour
{
    [SerializeReference]
    private float speed=1;

    [SerializeField]
    private float changeDirTime=3;

    private Vector2 curDir;

    private Rigidbody2D mybody;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(ChangeDirection), 0, changeDirTime);
    }

    private void ChangeDirection()
    {
        curDir = Random.rotationUniform * Vector2.up;
        if (curDir.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        mybody.velocity = curDir * speed;
        

    }

    private void OnBecameVisible()
    {
        enabled = true;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }
}
