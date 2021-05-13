using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChessMaster : PuzzleMasterBase
{
    [SerializeField]
    GameObject[] myMovables;

    private List<Vector2> positions = new List<Vector2>();

    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < myMovables.Length; i++)
        {
            positions.Add(myMovables[i].transform.position);
        }
    }

    protected override void DoAction()
    {
        //DisableMovementOfChilds();
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

    public override void ResetPuzzle()
    {
        base.ResetPuzzle();
        ResetPositions();
    }

    private void ResetPositions()
    {
        Debug.Log("Resetting puzzle");
        for(int i = 0; i < positions.Count; i++)
        {
            myMovables[i].transform.position = positions[i];
        }
    }
}
