using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChessMaster : PuzzleMasterBase
{
    [Header("Moving pieces")]
    [SerializeField]
    private int maxMovesBeforeWarning = 5;
    [SerializeField]
    private string dialogue;

    private int currentMoveAmmount;
    private bool hasClue = false;

    public bool HasClue
    {
        private get => hasClue;
        set
        {
            hasClue = value;
        }
    }


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
        for (int i = 0; i < myMovables.Length; i++)
        {
            positions.Add(myMovables[i].transform.position);
        }
    }

    protected override void DoAction()
    {
        GameManager.Instance.SetKey(DoorsAndNumbers.HouseDoor, true);
        DisableMovementOfChilds();
        StartCoroutine(UnlockDoorRoutine());
    }

    private void DisableMovementOfChilds()
    {
        foreach(PuzzleCollider child in myColliders)
        {
            child.ReturnFitObject().IsInteractible = false;
        }
    }

    private IEnumerator UnlockDoorRoutine()
    {
        CameraFollow.Instance.SetTarget(door.gameObject.transform);
        GameManager.Instance.GetPlayer().IsInteracting(InteractionType.DialogInteraction);
        yield return new WaitForSeconds(timeCam/2);
        door.OpenDoorNoKey();
        yield return new WaitForSeconds(timeCam / 2);
        CameraFollow.Instance.SetTarget(GameManager.Instance.GetPlayer().transform);
        base.DoAction();
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

    private int timesWarned = 0;

    public void OnPieceMove()
    {
        if (hasClue==false)
        {
            currentMoveAmmount++;
            if (currentMoveAmmount == maxMovesBeforeWarning)
            {
                //Do Dialogue
                currentMoveAmmount = 0;
                switch (timesWarned)
                {
                    default:
                    case 0:

                        break;
                    

                }
            }
        }
    }
}
