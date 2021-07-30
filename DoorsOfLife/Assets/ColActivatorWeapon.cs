using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColActivatorWeapon : ColActivator
{
    [SerializeField][ShowOnly]
    private bool playerHasWeapon = false;

    [SerializeField]
    private DialogueAndEvent[] newSentences;

    InteractDialogue diagSys;

    [SerializeField]
    private GameObject wall;

    bool hasSwapped = false;
    private void Start()
    {
        diagSys = mydiagInteract.GetComponent<InteractDialogue>();

        mydiagInteract.OnInteractionStopped += ChangeDiag;
    }

    public void SetHasWeapon()
    {
        playerHasWeapon = true;
        if (GameManager.Instance)
        {
            GameManager.Instance.GetPlayer().canAttack = true;
            GameManager.Instance.playerCanAttack = true;
        }
        Destroy(wall);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerHasWeapon) return;

        if (collision.gameObject.CompareTag(tagP))
        {
            Activate();
        }

        //ChangeDiag();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerHasWeapon) return;

        if (collision.CompareTag(tagP))
        {
            Activate();
        }

    }

    private void ChangeDiag()
    {
        if (hasSwapped) return;
        diagSys.SwapSentences(newSentences);
        hasSwapped = true;
    }
}
