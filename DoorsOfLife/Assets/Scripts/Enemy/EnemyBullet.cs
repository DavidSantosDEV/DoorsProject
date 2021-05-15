using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public Rigidbody2D myRBody2D;
    [SerializeField]
    private float bulletSpeed=10;
    [SerializeField][Range(0, 60)]
    private float damageToGive = 20;
    [SerializeField][Range(0,10)]
    private float VanishTimerInvisible = 2f;

    [SerializeField]
    private GameObject explosion;

    //private float reflectSpeedMultiplier = 1f;
    //private Vector2 bulletAngle;
    //private int maxReflectionCount = 5;

    /*public void SetupBullet(Vector2 angle, int maxReflectionsAllowed,float reflectionMultiplierSpeed)
    {
        bulletAngle = angle;
        maxReflectionCount = maxReflectionsAllowed;
        reflectSpeedMultiplier = reflectionMultiplierSpeed;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        myRBody2D.velocity = transform.right * bulletSpeed;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        /*switch (collision.transform.tag)
        {
            case "Enemy":
                Destroy(gameObject);
                collision.transform.GetComponent<HealthComponent>().TakeDamage(damageToGive);
                break;
            case "Reflectable":
                Reflect(collision);
                break;
            default:
                DestroySelf();
                break;
        }*
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyFeet")) return;

        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.GetPlayer().PlayerHealthComponent.TakeDamage(damageToGive);
            //PlayerController.Instance.playerHealthComponent.TakeDamage(damageToGive);
        }
        DestroySelf();
    }

    private void OnBecameInvisible()
    {
        if (VanishTimerInvisible==0)
        {
            Destroy(gameObject);
        }
        else
        {
            Invoke(nameof(DestroySelf), VanishTimerInvisible);
        }
    }
    private void OnBecameVisible()
    {
        CancelInvoke(nameof(DestroySelf));
    }

    private void DestroySelf()
    {
        if (explosion)
        {
            Instantiate(explosion, transform); //Please alter this later
        }
        
        Destroy(gameObject);
    }

   /* private void Reflect(Collision2D collision)
    {
        if (maxReflectionCount == 0) return;
        maxReflectionCount--;
        Vector2 newDirection = Vector2.Reflect(bulletAngle, collision.GetContact(0).normal);
        myRBody2D.velocity = newDirection * bulletSpeed * reflectSpeedMultiplier;
        //Debug.Log("Velocity Reflected: " + myRBody2D.velocity.normalized + " Angle: "+ (Vector2)(Quaternion.Euler(0, 0, bulletAngle) * Vector2.right));
    }*/
}
