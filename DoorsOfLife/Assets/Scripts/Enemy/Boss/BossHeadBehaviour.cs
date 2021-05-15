using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHeadBehaviour : MonoBehaviour
{
    private Animator bossAnimation;
    private CircleCollider2D myCol;

    bool isActive=false;

    public LayerMask attackLayerMask;

    [SerializeField] private float damage=20;
    [SerializeField][Range(0,5)] private float damageDif=5;

    void Start()
    {
        bossAnimation = GetComponent<Animator>();
        myCol = GetComponent<CircleCollider2D>();
        isActive = true;
    }

    public void Activate()
    {
        isActive = true;
        StartIdleAnimation();
    }

    public void DeActivate() //
    {
        isActive = false;
        StartDeathAnimation();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerFeet") && isActive)
        {
            AttackAnimation();
            Debug.Log("Hey");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerFeet")&& isActive)
        {
            AttackAnimation();
        }
    }

    private void AttackAnimation()
    {
        bossAnimation.SetTrigger("Attack");
    }

    public void AttackHead() //Used on Animator
    {
        Collider2D hit = Physics2D.OverlapCircle(myCol.bounds.center, myCol.bounds.size.x, attackLayerMask);
        if (hit)
        {
            GameManager.Instance.GetPlayer().PlayerHealthComponent.TakeDamage(damage-Random.Range(0,damageDif));
            //PlayerController.Instance.playerHealthComponent.TakeDamage(damage-Random.Range(0,damageDif));
        }
    }

    private void StartIdleAnimation()
    {
        bossAnimation.SetBool("isActive", true);
    }

    private void StartDeathAnimation()
    {
        bossAnimation.SetBool("isDead", true);
    }
}
