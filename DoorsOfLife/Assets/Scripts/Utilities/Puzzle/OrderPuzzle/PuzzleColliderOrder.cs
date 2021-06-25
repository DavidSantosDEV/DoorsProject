using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleColliderOrder : MonoBehaviour
{
    [SerializeField]
    private InteractPushObject myFitObject;

    private Vector2 directionReturn;

    private bool isSet;

    private PuzzleMasterOrder myMaster;

    private void Start()
    {
        directionReturn = -(transform.position - myFitObject.transform.position).normalized;
        Debug.Log(directionReturn);
    }

    public void SettupMaster(PuzzleMasterOrder master)
    {
        myMaster = master;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isSet) return;

        if (collision.gameObject == myFitObject.gameObject)
        {
            isSet = true;
            myFitObject.IsInteractible = false;
            myMaster.UpdateMaster(this);
        }
    }

    public void ResetPosition()
    {
        isSet = false;
        myFitObject.IsInteractible = true;
        myFitObject.MoveObject(directionReturn);
    }

}
