using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PuzzlePlayMaster : PuzzleMasterBase
{
    [SerializeField]
    private UnityEvent ChessPuzzleEvent;

    [SerializeField]
    private GameObject[] myMovables;

    [SerializeField][ShowOnly]
    List<Vector2> originalPositions = new List<Vector2>();

    [SerializeField]
    private GameObject showGameObject;

    protected override void Start()
    {
        base.Start();
        showGameObject.SetActive(false);
        SetOriginalPositions();
    }

    private void SetOriginalPositions()
    {
        originalPositions.Clear();
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
        Debug.Log("Puzzle complete!");
        showGameObject.SetActive(true);
        ChessPuzzleEvent.Invoke();
        base.DoAction();
    }



    public override void ResetPuzzle()
    {
        base.ResetPuzzle();
        ResetPositions();
    }

    
}
