using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField]
    private float movementSpeed=5f;

    [SerializeField]
    private Rigidbody2D myBody;

    private Vector2 movementDirection;

    private PlayerController _parent;
    //private Vector2 movementCalculated;

    private void Start()
    {
        //curRollTime = rollTime;
        //myBody = GetComponentInParent<Rigidbody2D>();
        //myBody = GetComponent<Rigidbody2D>();
        myBody.interpolation = RigidbodyInterpolation2D.Interpolate;
        myBody.gravityScale = 0;
        _parent = GetComponent<PlayerController>();
    }

    //Update movement data

    public void ClearMovement()
    {
        movementDirection = Vector2.zero;
        _parent.PlayerAnimationComponent.UpdateMovementSpeed(0);
    }

    public void MakeBodyStatic()
    {
        myBody.bodyType = RigidbodyType2D.Static;
    }

    public void MakeBodyDynamic()
    {
        myBody.bodyType = RigidbodyType2D.Dynamic;
    }

    public void UpdateMovementData(Vector2 movement)
    {
        //if(canMove)
        movementDirection = movement;
    }
    private void FixedUpdate()
    {
        myBody.velocity = movementDirection * movementSpeed;
    }
}
