using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PuzzleMasterBase : MonoBehaviour
{

    [SerializeField]
    protected PuzzleCollider[] myColliders;

    private void Start()
    {
        foreach(PuzzleCollider Pchild in myColliders)
        {
            if(Pchild)
            Pchild.SetMaster(this);
        }
    }

    public void UpdateMaster()
    {
        foreach(PuzzleCollider Pchild in myColliders)
        {
            if (Pchild.GetIsSet() == false) return;
        }
        DoAction();
    }


    protected virtual void DoAction()
    {
        Debug.Log("Puzzle Complete: "+gameObject.name);
        Destroy(this);
    }
}
