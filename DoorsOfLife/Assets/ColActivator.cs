using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ColActivator : MonoBehaviour
{
    [SerializeField]
    protected string tagP = "Player";

    [SerializeField]
    protected IInteractibleBase mydiagInteract;

    private void Awake()
    {
        if(!mydiagInteract)
        mydiagInteract = GetComponent<IInteractibleBase>();

        mydiagInteract.OnInteractionStopped += SentenceOver;
    }

    private void SentenceOver()
    {
        if (lastTime)
        {
            if (this && this.gameObject)
            {
                Destroy(this.gameObject);

            }
        }
    }

    public void Activate() //I just made it public to use it quick now
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

    private bool lastTime=false;

    public bool LastTime { set => lastTime=value; }
}
