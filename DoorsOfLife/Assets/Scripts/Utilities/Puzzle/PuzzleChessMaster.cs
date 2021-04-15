using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChessMaster : PuzzleMasterBase
{
    protected override void DoAction()
    {
        base.DoAction();
        DisableMovementOfChilds();
        DoWinEvent();
    }

    private void DisableMovementOfChilds()
    {
        foreach(PuzzleCollider child in myColliders)
        {
            child.ReturnFitObject().canPush = false;
        }
    }

    private void DoWinEvent()
    {
        
    }
}
