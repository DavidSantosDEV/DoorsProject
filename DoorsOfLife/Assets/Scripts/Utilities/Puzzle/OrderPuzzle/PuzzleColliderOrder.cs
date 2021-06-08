using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PuzzleColliderOrder : PuzzleCollider
{
    PuzzleMasterOrder _master;

    [System.Serializable]
    struct CollidersAndOrder
    {
        public PuzzleColliderOrder PzCol;
        public bool push;
    }

    [SerializeField]
    CollidersAndOrder[] brothers;

    private void Start()
    {
        if (myFitObject)
        {
            Vector3 pos = myFitObject.transform.position;
            Debug.Log((transform.position - pos).normalized); //FORMULA FOR DIRECTION
        }
        
        
    }

    protected override void TriggerCheck(Collider2D collision)
    {
        if (!_master.UpdateMaster(this))
        {
            ResetPositions();
        }
        else
        {
            pusher.IsInteractible = false;
        }
        //base.TriggerCheck(collision);
    }

    protected override void TriggerExitCheck(Collider2D collision)
    {

        //base.TriggerExitCheck(collision);
    }

    private void ResetPositions()
    {
        foreach(CollidersAndOrder cl in brothers)
        {
            if (cl.push)
            {
                cl.PzCol.ResetObject();
            }
        }
    }

    public void ResetObject()
    {
        pusher.IsInteractible = true;
    }
}
