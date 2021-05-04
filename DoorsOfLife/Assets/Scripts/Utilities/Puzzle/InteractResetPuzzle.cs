using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractResetPuzzle : IInteractibleBase
{
    [SerializeField]
    private PuzzleMasterBase myPuzzleMaster;
    public override void OnInteract()
    {
        base.OnInteract();
        myPuzzleMaster.ResetPuzzle();
    }
}
