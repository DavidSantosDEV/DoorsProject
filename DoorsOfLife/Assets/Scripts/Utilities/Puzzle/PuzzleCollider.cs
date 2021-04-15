using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCollider : MonoBehaviour
{
    private PuzzleMasterBase myMaster;

    [SerializeField]
    private GameObject myFitObject;

    private ObjectPusher pusher;

    private void Start()
    {
        if(myFitObject)
        pusher = myFitObject.GetComponent<ObjectPusher>();
    }


    private bool amIHappy = false;

    public ObjectPusher ReturnFitObject()
    {
        return pusher;
    }

    public bool GetIsSet()
    {
        return amIHappy;
    }

    public void SetMaster(PuzzleMasterBase master)
    {
        myMaster = master;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter trig");
        if (collision.gameObject== myFitObject)
        {
            amIHappy = true;
            myMaster.UpdateMaster();
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == myFitObject)
        {
            amIHappy = false;
            myMaster.UpdateMaster();
        }
    }
}
