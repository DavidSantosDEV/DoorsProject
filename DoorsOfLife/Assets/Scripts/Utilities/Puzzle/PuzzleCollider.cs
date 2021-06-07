using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCollider : MonoBehaviour
{
    protected PuzzleMasterBase myMaster;

    [SerializeField]
    protected GameObject myFitObject;

    protected InteractPushObject pusher;

    private void Awake()
    {
        if(myFitObject)
        pusher = myFitObject.GetComponent<InteractPushObject>();
    }

    [SerializeField][ShowOnly]
    private bool isSet = false;

    public InteractPushObject ReturnFitObject()
    {
        return pusher;
    }

    public bool GetIsSet()
    {
        return isSet;
    }

    public void SetMaster(PuzzleMasterBase master)
    {
        myMaster = master;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerCheck(collision);
    }

    protected virtual void TriggerCheck(Collider2D collision)
    {
        if (collision.gameObject == myFitObject)
        {
            isSet = true;
            myMaster.UpdateMaster();
        }
    }

    protected virtual void TriggerExitCheck(Collider2D collision)
    {
        if (collision.gameObject == myFitObject)
        {
            isSet = false;
            myMaster.UpdateMaster();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TriggerExitCheck(collision);
    }
}
