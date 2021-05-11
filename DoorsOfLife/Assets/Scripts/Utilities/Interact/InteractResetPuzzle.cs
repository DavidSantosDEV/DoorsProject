using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractResetPuzzle : IInteractibleBase
{
    [SerializeField]
    private PuzzleMasterBase myPuzzleMaster;

    private void Start()
    {
        typeInteraction = InteractionType.OneTimeClick;//Just in case i forget in editor
    }

    public override void OnInteract()
    {
        base.OnInteract();
        myPuzzleMaster.ResetPuzzle();
    }
}
