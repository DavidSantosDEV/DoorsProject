using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PuzzleMasterBase : MonoBehaviour
{

    [SerializeField]
    private PuzzleCollider[] myChildren;

    private void Start()
    {
        foreach(PuzzleCollider Pchild in myChildren)
        {
            if(Pchild)
            Pchild.SetMaster(this);
        }
    }

    public void UpdateMaster()
    {
        foreach(PuzzleCollider Pchild in myChildren)
        {
            if (Pchild.GetIsSet() == false) return;
        }
        DoAction();
    }


    protected virtual void DoAction()
    {
        Debug.Log("Puzzle Complete: "+gameObject.name);
    }
}
