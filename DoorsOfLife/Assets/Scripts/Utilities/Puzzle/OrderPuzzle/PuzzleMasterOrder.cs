using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


public class PuzzleMasterOrder : MonoBehaviour
{
    [SerializeField]
    List<PuzzleColliderOrder> collidersAndOrder = new List<PuzzleColliderOrder>();

    public UnityEvent puzzleComplete;

    private int currentIndex=0;

    private void Start()
    {
        List<PuzzleColliderOrder> toRemove = new List<PuzzleColliderOrder>();
        foreach(PuzzleColliderOrder pzCol in collidersAndOrder)
        {
            if (pzCol)
            {
                pzCol.SettupMaster(this);
            }
            else
            {
                toRemove.Add(pzCol);
            }
        }

        foreach(PuzzleColliderOrder pz in toRemove)
        {
            collidersAndOrder.Remove(pz);
        }
    }

    public void UpdateMaster(PuzzleColliderOrder ColliderUpdated)
    {
        if (collidersAndOrder[currentIndex] == ColliderUpdated)
        {
            currentIndex++;
            if(currentIndex == collidersAndOrder.Count)
            {
                PuzzleComplete();
            }
        }
        else
        {
            ResetPuzzle();
        }
    }

    private void ResetPuzzle()
    {
        currentIndex = 0;
        foreach(PuzzleColliderOrder pzCol in collidersAndOrder)
        {
            pzCol.ResetPosition();
        }
    }

    private void PuzzleComplete()
    {
        puzzleComplete.Invoke();
        //ResetPuzzle();
        //Debug.Log("yeah");

    }

    public void DebugFunc()
    {
        if(Debug.isDebugBuild)
        ResetPuzzle();
    }
}
