using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InteractPushChess : InteractPushObject
{
    PuzzleChessMaster masterChess;
    private void Awake()
    {
        masterChess = FindObjectOfType<PuzzleChessMaster>();
    }

    public override void MoveObject(Vector3 direction)
    {
        base.MoveObject(direction);
        masterChess.OnPieceMove();
    }
}
