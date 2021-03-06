using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleChessMaster : PuzzleMasterBase
{
    [SerializeField]
    private UnityEvent eventPuzzleComplete;

    [Header("Moving pieces")]
    [SerializeField]
    private int maxMovesBeforeWarning = 5;

    private int currentMoveAmmount;
    private bool hasClue = false;

    public void SetHasClue()
    {
        hasClue = true;
    }

    private InteractDialogue myDiagInteract;

    [Space]
    [SerializeField]
    private float timeCam;
    [SerializeField]
    private DoorInteractible door;

    [SerializeField]
    GameObject[] myMovables;

    private List<Vector2> positions = new List<Vector2>();

    protected override void Start()
    {
        base.Start();

        myDiagInteract = GetComponent<InteractDialogue>();

        for (int i = 0; i < myMovables.Length; i++)
        {
            positions.Add(myMovables[i].transform.position);
        }
    }

    protected override void DoAction()
    {
        GameManager.Instance.SetKey(DoorsAndNumbers.HouseDoor, true);
        DisableMovementOfChilds();
        eventPuzzleComplete?.Invoke();
        StartCoroutine(UnlockDoorRoutine());
    }

    /*private void DisableMovementOfChilds()
    {
        foreach(PuzzleCollider child in myColliders)
        {
            child.ReturnFitObject().IsInteractible = false;
        }
    }*/

    private IEnumerator UnlockDoorRoutine()
    {
        if (door)
        {
            //CameraFollow.Instance.SetTarget(door.gameObject.transform);
            GameManager.Instance.GetPlayer().IsInteracting(InteractionType.DialogInteraction);
            yield return new WaitForSeconds(timeCam / 4);
            door.OpenDoorNoKey();
            base.DoAction();
        }
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

    //private int timesWarned = 0;

    public void OnPieceMove()
    {
        Debug.Log("Moved");
        if (hasClue==false)
        {
            currentMoveAmmount++;
            if (currentMoveAmmount >= maxMovesBeforeWarning)
            {
                Debug.Log("Moved it too many times");
                //Do Dialogue
                currentMoveAmmount = 0;

                GameManager.Instance.GetPlayer().InCutscene = true;
                GameManager.Instance.GetPlayer().interactionData.ResetData();
                GameManager.Instance.GetPlayer().interactionData.Interactible = myDiagInteract;
                GameManager.Instance.GetPlayer().interactionData.Interact();

                hasClue = true;
            }
        }
    }
}
