using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPusher : MonoBehaviour
{
    [SerializeField]
    private float moveDistanceMultiplier = 1;
    [SerializeField]
    private float timeToMove=0.1f;
    [SerializeField]
    private LayerMask layersCheck;

    [SerializeField]
    private float distanceRayTolerance = 0.05f;

    public bool canPush = true; //If its false just don't move bruh

    private float raySize = 3;
    private bool isMoving=false;

    private Vector3 origPos;
    private Vector3 targetPos;

    private void Awake()
    {
        raySize = ((GetComponent<Collider2D>().bounds.size.x*1.5f) * moveDistanceMultiplier) - distanceRayTolerance;
    }

    public virtual void MoveObject(Vector3 direction)
    {
        if (isMoving || !canPush) return;
        direction*= moveDistanceMultiplier;
        if (CheckCollision(direction)) return;
        StartCoroutine(Move(direction));
    }

    private bool CheckCollision(Vector3 direction)
    {
        RaycastHit2D[] _hits = Physics2D.RaycastAll(transform.position, direction, raySize,layersCheck);
        
        foreach (RaycastHit2D hit in _hits)
        {
            if (hit.transform.gameObject != gameObject)
            {
                Debug.DrawRay(transform.position, direction * raySize, Color.red);
                return true;
            }
        }
        Debug.DrawRay(transform.position, direction * raySize, Color.green);
        return false;
    }

    private IEnumerator Move(Vector3 direction)
    {

        isMoving = true;
        float elapsedTime=0;
        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove && transform.position!=targetPos)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }
}
