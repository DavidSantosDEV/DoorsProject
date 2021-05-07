using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePlayMaster : PuzzleMasterBase
{
    [SerializeField]
    private GameObject[] myMovables;

    [SerializeField]
    List<Vector2> originalPositions = new List<Vector2>();

    protected override void Start()
    {
        base.Start();
        SetOriginalPositions();
    }

    private void SetOriginalPositions()
    {
        for(int i = 0; i < myMovables.Length; i++)
        {
            if(myMovables[i])
            originalPositions.Add(myMovables[i].transform.position);
        }
    }
    private void ResetPositions()
    {
        for (int i = 0; i < myMovables.Length;i++)
        {
            myMovables[i].transform.position = originalPositions[i];
        }
    }

    protected override void DoAction()
    {
        base.DoAction();
    }



    public override void ResetPuzzle()
    {
        base.ResetPuzzle();
        ResetPositions();
    }

    
}
