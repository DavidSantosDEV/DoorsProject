using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField]
    private float movementSpeed=5f;
    //[SerializeField]
    //private float dodgeAmmount = 4f;
    //[SerializeField]
    //private float rollTime=3f;
    //[SerializeField]
    //private float rollTimeDropMultiplier = 5f;
    //[SerializeField]
    //private float dropMinCheck = 4f;
    //private float curRollTime;
    //private Vector2 currentDodgedirection;
    //private Vector2 lastmovementInput;

    //private bool isDodging = false;
    //Components needed
    public Rigidbody2D myBody;


    private Vector2 movementDirection;
    //private Vector2 movementCalculated;

    private void Start()
    {
        //curRollTime = rollTime;
        //myBody = GetComponentInParent<Rigidbody2D>();
        //myBody = GetComponent<Rigidbody2D>();
        myBody.interpolation = RigidbodyInterpolation2D.Interpolate;
        myBody.gravityScale = 0;
    }

    //Update movement data

    public void ClearMovement()
    {
        movementDirection = Vector2.zero;
        PlayerController.Instance.playerAnimation.UpdateMovementSpeed(0);
    }

    public void UpdateMovementData(Vector2 movement)
    {
        movementDirection = movement;
    }

    /*private void Update()
    {
        if (isDodging)
        {
            curRollTime -= rollTime * rollTimeDropMultiplier*Time.deltaTime;
            if (curRollTime < dropMinCheck)
            {
                isDodging = false;
                curRollTime = rollTime;
            }
        }
        //if (movementCalculated != Vector2.zero) lastmovementInput = movementCalculated;
        //Debug.Log(lastmovementInput);
    }*/

    private void FixedUpdate()
    {
        /*if (isDodging)
        {   
            myBody.velocity = currentDodgedirection * rollTime;
        }
        else
        {*/
        MovePlayer();
        //}
    }

    private void MovePlayer()
    {
        Vector2 move= movementDirection * movementSpeed;
        myBody.velocity = move;
    }

    /*public void Dodge()
    {
        if (isDodging) return;
        currentDodgedirection = movementDirection.normalized * dodgeAmmount;
        isDodging = true;
    }*/
}
