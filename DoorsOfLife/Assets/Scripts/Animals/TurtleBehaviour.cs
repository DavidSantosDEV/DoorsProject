using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleBehaviour : MonoBehaviour
{
    [SerializeReference]
    private float speed=1;

    [SerializeField]
    private LayerMask layersToCheck;
    [SerializeField]
    private float raySize = 2;

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
        CheckFlip();
    }

    private void CheckFlip()
    {
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
        if (Physics2D.Raycast(transform.position, transform.right, raySize, layersToCheck))
        {
            curDir = new Vector2(-curDir.x, curDir.y) ;
            CheckFlip();
        }
        mybody.velocity = curDir * speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, this.transform.right * raySize);
        //Gizmos.DrawLine(transform.position, transform.right * raySize);
    }
}
