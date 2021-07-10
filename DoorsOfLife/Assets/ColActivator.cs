using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ColActivator : MonoBehaviour
{
    [SerializeField]
    private string tagP = "Player";

    IInteractibleBase mydiagInteract;

    private void Awake()
    {
        mydiagInteract = GetComponent<IInteractibleBase>();
    }

    private void Activate()
    {
        if (mydiagInteract == null)
        {
            mydiagInteract = GetComponent<IInteractibleBase>();
        }
        if (mydiagInteract.IsInteractible)
        {
            if (GameManager.Instance)
            {
                GameManager.Instance.GetPlayer().inCutscene = true;
                GameManager.Instance.GetPlayer().interactionData.ResetData();
                GameManager.Instance.GetPlayer().interactionData.Interactible = mydiagInteract;
                GameManager.Instance.GetPlayer().interactionData.Interact();
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagP)){
            Activate();
        } 
    }
}
