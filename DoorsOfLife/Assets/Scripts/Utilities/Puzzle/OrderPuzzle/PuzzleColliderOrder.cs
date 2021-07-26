using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleColliderOrder : MonoBehaviour
{
    [SerializeField]
    private InteractPushObject myFitObject;
    [SerializeField]
    private float YOffset = 0.5f;

    private Vector2 directionReturn;

    [SerializeField][ShowOnly]
    private bool isSet;

    private PuzzleMasterOrder myMaster;

    private void Start()
    {
        Vector3 objPos = (myFitObject.transform.position - new Vector3(0, YOffset, 0));
        directionReturn = -(transform.position - objPos).normalized;
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
            myFitObject.ToBeSetNotInteractible() ;
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
