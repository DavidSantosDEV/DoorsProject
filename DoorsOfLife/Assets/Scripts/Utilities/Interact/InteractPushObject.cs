using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPushObject : IInteractibleBase
{
    [SerializeField]
    private float YOffset=0;

    [SerializeField]
    private float moveDistanceMultiplier = 1;
    [SerializeField]
    private float timeToMove = 0.1f;
    [SerializeField]
    private LayerMask layersCheck;

    [SerializeField]
    private float distanceRayTolerance = 0.05f;

    public bool canPush = true; //If its false just don't move bruh

    private float raySize = 3;
    private bool isMoving = false;

    private Vector3 origPos;
    private Vector3 targetPos;

    bool willReset=true;
    public void ToBeSetNotInteractible()
    {
        willReset = false;
    }

    private void Start()
    {
        typeInteraction = InteractionType.OneTimeClick;
        raySize = ((GetComponent<Collider2D>().bounds.size.x * 1.5f) * moveDistanceMultiplier) - distanceRayTolerance;
    }

    public override void OnInteract()
    {
        base.OnInteract();
        Vector3 dir = GameManager.Instance.GetPlayer().ReturnFacingDirection();
        if (!(dir.x == dir.y || dir.x == -dir.y)) MoveObject(dir);
    }

    private List<Vector2> moveLine= new List<Vector2>();
    public virtual void MoveObject(Vector3 direction)
    {
        if (isMoving)
        {
            moveLine.Add(direction * moveDistanceMultiplier);
            return;
        }
        if (!canPush) return;
        direction *= moveDistanceMultiplier;
        if (CheckCollision(direction)) return;
        StartCoroutine(Move(direction));
    }

    private bool CheckCollision(Vector3 direction)
    {
        Vector3 offset = new Vector3(0, YOffset, 0);
        Vector3 StartPoint = transform.position - offset;
        Debug.Log(StartPoint);
        RaycastHit2D[] _hits = Physics2D.RaycastAll(StartPoint, direction, raySize, layersCheck);

        foreach (RaycastHit2D hit in _hits)
        {
            if (hit.transform.gameObject != gameObject)
            {
                Debug.DrawRay(StartPoint, direction * raySize, Color.red);
                return true;
            }
        }
        Debug.DrawRay(StartPoint, direction * raySize, Color.green);
        return false;
    }

    private IEnumerator Move(Vector3 direction)
    {
        interactionSound?.Play();
        isInteractible = false;
        isMoving = true;
        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove && transform.position != targetPos)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;

        isInteractible = willReset;//true;
        willReset = true;
        if (moveLine.Count > 0)
        {
            Vector2 moveVal = moveLine[0];
            moveLine.Remove(moveVal);
            StartCoroutine(Move(moveVal));
        }
    }
    
}
