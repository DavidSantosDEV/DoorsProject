using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    bool interacted = false;

    private InteractDialogue diag;
    private void Awake()
    {
        diag= GetComponent<InteractDialogue>();
        diag.OnInteractionStopped += EndGameFunc;
    }

    private void EndGameFunc()
    {
        UIManager.Instance?.ShowThanksForPlaying();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (interacted) return;
        if (collision.CompareTag("Player"))
        {       
            if (GameManager.Instance)
            {
                interacted = true;
                GameManager.Instance.GetPlayer().inCutscene = true;
                GameManager.Instance.GetPlayer().interactionData.ResetData();
                GameManager.Instance.GetPlayer().interactionData.Interactible = diag;
                GameManager.Instance.GetPlayer().interactionData.Interact();
            }
        }
    }


}
