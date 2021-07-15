using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;

public class IInteractibleBase : MonoBehaviour,IInteractible
{
    public event Action OnInteractionStopped;

    [Header("Interactible Settings")]
    [SerializeField]
    protected AudioSource interactionSound;
    [SerializeField]
    protected bool multipleUse=true;
    [SerializeField]
    protected bool isInteractible=true;
    [SerializeField]
    protected InteractionType typeInteraction;
    [SerializeField]
    protected string interactionText = "Interact";

    public AudioSource InteractionSound => interactionSound;
    public bool MultipleUse => multipleUse;
    public bool IsInteractible
    {
        get => isInteractible;
        set => isInteractible = value;
    }
    public InteractionType TypeInteraction=>typeInteraction;
    public string InteractionText => interactionText;


    public virtual void OnInteract()
    {
        Debug.Log("Interacted: " + gameObject.name);
        GameManager.Instance?.GetPlayer().IsInteracting(typeInteraction);

    }

    public virtual void OnContinueInteract()
    {
        Debug.Log("Next phase interact");
    }

    public virtual void OnStopInteraction()
    {
        Debug.Log("Interaction Stopped");
        GameManager.Instance.GetPlayer().StoppedInteracting();
        isInteractible = multipleUse;
        if (OnInteractionStopped != null)
        {
            OnInteractionStopped.Invoke();
        }
    }

    /*[SerializeField]
protected float holdDuration;
[SerializeField]
protected bool holdInteract;*/

    /*public float HoldDuration => holdDuration;
public bool HoldInteract => holdInteract;*/

    #region Old Prompt code
    //public Canvas promptCanvas;

    //private Image promptImg;
    /*public virtual void ShowPrompt()
    {
        if (promptCanvas)
        {
            ChangePrompt(UIManager.Instance.getInteractSprite());
            promptCanvas.enabled = true;
        }
        else
        {
            //Debug.Log("Object :" + gameObject.name + " needs prompt");
        }
        
    }

    public virtual void HidePrompt()
    {
        if (promptCanvas)
        {
            promptCanvas.enabled = false;

        }
        else
        {
            //Debug.Log("Object :" + gameObject.name + " needs prompt");
        }
    }

    public virtual void ChangePrompt(Sprite spt)
    {
        promptImg.sprite = spt;
    }*/
    #endregion
}
