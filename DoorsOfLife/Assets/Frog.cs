using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField]
    private float timeBetweenJump = 5;

    [SerializeField]
    private float JumpForce=300;

    bool canJump = true;
    bool isAlert = false;
    
    private int jumpAnim;

    private Animator animator;
    private Rigidbody2D mybody;

    private void JumpRandom()
    {
        if (canJump && !isAlert)
        {
            animator.SetTrigger(jumpAnim);
            Vector2 vol = (Random.rotationUniform * Vector2.up) * JumpForce;//new Vector2(Random.1value, Random.value);
            mybody.velocity = vol;//new Vector2(aux, 0);
            CheckFlip(vol.x);
        }
        
    }

    private void CheckFlip(float x)
    {
        if (x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    private void JumpDir(Vector2 direction)
    {
        if (canJump)
        {
            animator.SetTrigger(jumpAnim);
            mybody.velocity = direction;
            CheckFlip(direction.x);
        }
    }

    public void StopMovement()
    {
        canJump = true;
        mybody.velocity = Vector2.zero;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();

        jumpAnim = Animator.StringToHash("Jump");

        InvokeRepeating(nameof(JumpRandom), timeBetweenJump, timeBetweenJump); 
    }

    private void ResetState()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //canJump = !isAlert;
            isAlert = true;      
            JumpDir((transform.position - collision.transform.position).normalized);
        }
        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAlert = false;
        }
    }

}
