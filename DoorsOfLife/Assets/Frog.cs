using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField]
    private float timeBetweenJump = 5;
    [SerializeField]
    private float rangeToleranceJumpTime = 2;

    [SerializeField]
    private float JumpForce=300;

    private float aux,prev;

    bool canJump = true;

    private Animator animator;

    private int jumpAnim;

    private void Jump()
    {
        if (!canJump) return;
        canJump = false;
        if(Random.Range(0,100) > 50)
        {
            aux = JumpForce;
        }
        else
        {
            aux = -JumpForce;
        }
        if (aux!=prev)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y+ 180, 0);
        }
        prev = aux;
        StartCoroutine(nameof(RoutineOfJump));
        //mybody.AddForce(new Vector2(aux, 0));
    }

    private IEnumerator RoutineOfJump()
    {
        animator.SetTrigger(jumpAnim);
        mybody.velocity = new Vector2(aux, 0);
        yield return new WaitForSeconds(1/1.5f);
        canJump = true;
        mybody.velocity = Vector2.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * 2);
    }

    private Rigidbody2D mybody;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();

        jumpAnim = Animator.StringToHash("Jump");

        InvokeRepeating(nameof(Jump), 1, 1); 
    }


}
