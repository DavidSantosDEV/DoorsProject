using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChessMaster : PuzzleMasterBase
{
    protected override void DoAction()
    {
        DisableMovementOfChilds();
        VictoryScenario();
        base.DoAction();//Destroy component, no longer needed
    }

    private void DisableMovementOfChilds()
    {
        foreach(PuzzleCollider child in myColliders)
        {
            child.ReturnFitObject().canPush = false;
        }
    }

    private void VictoryScenario()
    {
        GameManager.Instance.SetKey(DoorsAndNumbers.HouseDoor, true);
    }
}
