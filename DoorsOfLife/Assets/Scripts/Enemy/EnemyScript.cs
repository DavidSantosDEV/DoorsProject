using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using Pathfinding;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    protected bool isDead=false;

    public bool IsDead
    {
        get=>isDead;
    }

    protected bool stunned=false;

    protected Vector2 directionForAttack;

    private AIDestinationSetter enemyPathSetter;
    private AIPath enemyPathAI;

    protected EnemySoundManager enemySound;
    protected EnemyAnimator enemyAnimation;
    protected EnemyHearts enemyHearts;

    protected Rigidbody2D enemyBody;

    //protected EnemyHealth enemyHealth;
    //protected Rigidbody2D myRigidbody;

    [Header("Enemy Settings")]
    [SerializeField]
    protected float deAggroTime=10;
    [SerializeField][Range(0,10)]
    protected float findPlayerDistance=10;
    [SerializeField][Range(0,5)]
    protected float rangeToAttack=2;
    [SerializeField][Range(0,10)]
    protected float timeBetweenAttack=3;

    [SerializeField]
    protected float vanishAfterDeathTime=10;

    protected bool canAttack = true;

    [SerializeField]
    private Transform parentPosOrganizer;
    //Starting position
    private Transform startPos;

    [SerializeField]
    float maxStartDistance=5;


    [Header("Attack")]
    [SerializeField]
    protected Transform attackPoint=null;
    [SerializeField][Range(0,3)]
    protected float meleePointWidth = 1;
    [SerializeField]
    protected float meleeAttackRange=3;
    [SerializeField]
    protected float damage=20;
    [SerializeField][Range(0,20)]
    protected float damageDifferentiation=3;
    [SerializeField]
    protected LayerMask enemyHitLayer;

    private bool isChasing = false;
    private bool isVisible=true;
    private bool returning = false;

    #region Visibility
    //The why these two functions need to exist is the following, he has a max distance yes,
    //however imagine he is blocked because of pathfinding and the player already moved away, hence after a while he'll just return to the spawn as he should.
    private void OnBecameInvisible()
    {
        isVisible = false;
        Debug.Log("Visibility: "+isVisible);
        if (isChasing)
        {
            Invoke(nameof(SetStateReturning), deAggroTime);
        }
        else
        {
            enabled = false;
            enemyPathAI.enabled = false;
            enemyPathSetter.enabled = false;
        }
    }



    private void OnBecameVisible()
    {
        isVisible = true; 
        Debug.Log("Visibility: "+isVisible);
        if (isChasing)
        {
            CancelInvoke(nameof(SetStateReturning));
        }
        else
        {
            enabled = true;
            enemyPathAI.enabled = true;
            enemyPathSetter.enabled = true;
        }
    }

    private IEnumerator AmIHomeYet() //Useles code
    {
        bool isHome = false;
        while (!isHome && isChasing==false)
        {
            Debug.Log("distance: " + Vector2.Distance(transform.position, startPos.position));
            yield return new WaitForSeconds(0.1f);
            if (Vector2.Distance(transform.position, startPos.position) < 1)
            {
                Debug.Log("I am Home");
                isHome = true;
                enemyPathAI.enabled = false;
                enemyPathSetter.target = null;
                if (isVisible!)
                    enabled = false;
            }
        }    
    }
    #endregion


    void Awake()
    {
        GameObject stpos = new GameObject("Startpos_"+gameObject.name);
        stpos.transform.position = transform.position;    
        startPos = stpos.transform;
        if (parentPosOrganizer != null)
        {
            stpos.transform.parent = parentPosOrganizer;
        }
        stpos.isStatic = true;
        //Instantiate(prefab, transform.position, transform.rotation);


        enemyPathSetter = GetComponentInParent<AIDestinationSetter>();
        enemyPathAI = GetComponentInParent<AIPath>();

        //----------------

        enemySound = GetComponentInChildren<EnemySoundManager>();

        enemyAnimation = GetComponent<EnemyAnimator>();

        //enemyHealth = GetComponent<EnemyHealth>();
        enemyHearts = GetComponent<EnemyHearts>();
        enemyHearts.SettupComponent(this, enemyAnimation);
        //enemyHealth.SettupComponent(this, enemyAnimation);
        

        startPos.position = transform.position;

        enemyBody = GetComponentInParent<Rigidbody2D>();

        isVisible = GetComponent<Renderer>().isVisible;
        Debug.Log(isVisible);
        enabled = isVisible;
        enemyPathAI.enabled = isVisible;
        enemyPathSetter.enabled = isVisible;
    }

    protected PlayerController player;

    protected virtual void Start()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.OnEnemiesPause += OnGamePause;
            GameManager.Instance.GameUnPaused += OnGameUnPause;

            GameManager.Instance.AddEnemy(this);
        }

        player = GameManager.Instance != null ? GameManager.Instance.GetPlayer() : FindObjectOfType<PlayerController>();

    }

    protected virtual void OnDrawGizmos()
    {     
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, findPlayerDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeToAttack);
    }

    

    void Update() 
    {
        //I was using a state machine with states like Attacking, Returning, Roaming etc
        //After some decisions were made we decided it was best to just have the enemy idle instead of Roaming
        //This happened due to the change in pathfinding, before I was using an altered version of Unity's pathfinding system adapted for 2d
        //I am now using a Special package called A* (A-Star), much better at pathfinding than the one I was using before only downfall i can't make them roam in random positions the way I used to

        if (stunned || isDead) return;
        //if (GameManager.Instance.GameIsPaused) return;

        enemyAnimation.UpdateMovementAnimation(enemyPathAI.velocity);

        if (returning) //I wanted this to be a simple courotine but unity doesnt let me put enabled=false on it
        {
            FindTarget();
            if (!isChasing && Vector2.Distance(transform.position, startPos.position) < 1)
            {
                Debug.Log("I am Home");
                enemyPathAI.enabled = false;
                enemyPathSetter.target = null;
                returning = false;
                enemyAnimation.UpdateMovementAnimation(Vector3.zero);
                enabled = isVisible;
            }
        }
        else
        {
            FarFromStart();
            if (!isChasing)
            {
                FindTarget();
            }
            else
            {
                if (PathUtilities.IsPathPossible(AstarPath.active.GetNearest(transform.position, NNConstraint.Default).node, AstarPath.active.GetNearest(player.GetPositionVector3() /*GameManager.Instance.GetPlayer().GetPositionVector3()*/, NNConstraint.Default).node)) //<- Mombo jumbo for "If you can reach the player
                {
                    if (canAttack && Vector2.Distance(transform.position,player.GetPositionVector2() /*GameManager.Instance.GetPlayer().GetPositionVector2()*/) < rangeToAttack)
                    {
                        Attack();
                    }
                }
                else
                {
                    SetStateReturning();
                }
            }
            
        }
        //enemyAnimation.UpdateMovementAnimation(enemyPathAI.velocity);
    }

    private void OnGamePause()
    {
        if(this)
        enabled = false;
    }

    private void OnGameUnPause()
    {
        if(this)
        enabled = true;
    }

    protected void SetStateReturning()
    {
        isChasing = false;

        enemyPathSetter.target = startPos;
        returning = true;

        MusicManager.Instance?.RemoveEnemyAlert(this);
        Debug.Log("Started courotine");
        //}
        
    }

    public void ResetSelf()
    {
        SetStateReturning();
    }

    protected void FarFromStart()
    {
        if (Vector2.Distance(transform.position, startPos.position) > maxStartDistance)
        {
            SetStateReturning();
        }
    }

    protected void FindTarget()
    {
        if (Vector2.Distance(transform.position, player.GetPositionVector2() /*GameManager.Instance.GetPlayer().GetPositionVector2()*/) < findPlayerDistance)
        {
            if (player.PlayerHeartsComponent.IsDead == false)
            {
                returning = false;
                isChasing = true;
                SetTargetPlayer();
                MusicManager.Instance?.AddEnemyAlert(this);
            }
        }
    }

    private void SetTargetPlayer()
    {
        enemyPathSetter.target = player.transform;//GameManager.Instance.GetPlayer().transform;
    }

    #region Movement

    public void StopMovement()
    {
        if (isChasing)
        {
            enemyPathSetter.target = null;
        }

        enemyPathAI.canMove = false;
        enemyPathAI.enabled = false;
        enemyPathSetter.enabled = false;
    }

    public void BeginMovement()
    {
        if (isChasing)
        {
            SetTargetPlayer();
        }
        enemyPathAI.canMove = true;
        enemyPathAI.enabled = true;
        enemyPathSetter.enabled = true;
    }
   

    public void SetStunned()
    {
        //StopMovement();
        stunned = true;
    }

    public void ResetStunned()
    {
        stunned = false;
        //BeginMovement();
        //state = EnemyState.Chasing; //Lets use this one cause if the player is close it'll just change to Chasing quickly i guess
    }

    //Attacking code

    /*public void ReturnToChasing() //TO DELETE AND THE SCRIPTS REFERENCING IT TOO
    {
        BeginMovement();
        //state = EnemyState.Chasing;
    }*/

    #endregion

    #region Attack Related Code

    protected virtual void Attack()
    {
        StopMovement();
        //state = EnemyState.Attacking;
        directionForAttack = player.GetPositionVector3() - transform.position;
        //directionForAttack = GameManager.Instance.GetPlayer().GetPositionVector3() - transform.position;
        if (Mathf.Abs(directionForAttack.x) > Mathf.Abs(directionForAttack.y))
        {
            if (directionForAttack.x > 0)
            {
                directionForAttack = -Vector2.left;
            }
            else
            {
                directionForAttack = Vector2.left;
            }
        }
        else
        {
            if (directionForAttack.y > 0)
            {
                directionForAttack = Vector2.up;
            }
            else
            {
                directionForAttack = -Vector2.up;
            }
        }
        
        enemyAnimation.PlayAttackMeleeAnimation(directionForAttack);

        canAttack = false;
        Invoke(nameof(ResetAttack), timeBetweenAttack);
    }

    //protected Vector2 newAttackDir;//delete after
    protected float damagetoGive;
    public virtual void MeleeDamage() //Used on animator
    {
        Debug.Log("Attacking");
        damagetoGive = Mathf.Round(damage - Random.Range(0, damageDifferentiation));
    }

    protected void ResetAttack()
    {
        canAttack = true;
    }

    #endregion


    //Death Related code

    #region Death Code
    public void OnEnemyDied()
    {
        MusicManager.Instance?.RemoveEnemyAlert(this);
        isDead = true;
        enemyPathAI.enabled = false;
        enemyBody.bodyType = RigidbodyType2D.Static;
        //state = EnemyState.Inactive;
        StopMovement();
        Invoke(nameof(OnSelfDestruction), vanishAfterDeathTime);
    }

    public void OnSelfDestruction() //To be called on animation event
    {
        enemyAnimation.PlayVanishAnimation();
    }

    public void LetMeDie() //Called by Animator
    {
        Destroy(gameObject.transform.parent.gameObject);
    }

    #endregion

}
