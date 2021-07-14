using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PuzzleMasterBase : MonoBehaviour
{

    [SerializeField]
    protected PuzzleCollider[] myColliders;

    bool isComplete = false;

    protected virtual void Start()
    {
        foreach(PuzzleCollider Pchild in myColliders)
        {
            if(Pchild)
            Pchild.SetMaster(this);
        }
    }

    public virtual void UpdateMaster()
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
        isComplete = true;
        Destroy(this);
    }

    public void debugCompletePuzzle()
    {
        DoAction();
    }

    protected void DisableMovementOfChilds()
    {
        foreach (PuzzleCollider child in myColliders)
        {
            InteractPushObject obj = child.ReturnFitObject();
            obj.IsInteractible = false;
            obj.canPush = false;
        }
    }

    public virtual void ResetPuzzle()
    {
        Debug.Log("Puzzle Reset");
        if (isComplete) return;
    }
}
