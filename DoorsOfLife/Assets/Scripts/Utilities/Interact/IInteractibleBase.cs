using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IInteractibleBase : MonoBehaviour,IInteractible
{
    [Header("Interactible Settings")]
    public AudioSource interactionSound;
    public float holdDuration;
    public bool holdInteract;
    public bool multipleUse;
    public bool isInteractible;
    public InteractionType typeInteraction;

    public Canvas promptCanvas;
    private Image promptImg;

    public AudioSource InteractionSound => interactionSound;
    public float HoldDuration => holdDuration;
    public bool HoldInteract => holdInteract;
    public bool MultipleUse => multipleUse;
    public bool IsInteractible => isInteractible;
    public InteractionType TypeInteraction=>typeInteraction;

    protected virtual void Start()
    {
        if (!promptCanvas) promptCanvas = GetComponentInChildren<Canvas>();
        if (promptCanvas) promptImg = GetComponentInChildren<Image>();
        HidePrompt();
    }

    public virtual void OnInteract()
    {
        Debug.Log("Interacted: " + gameObject.name);
        PlayerController.Instance.IsInteracting(typeInteraction);
    }

    public virtual void OnContinueInteract()
    {
        Debug.Log("Next phase interact");
    }

    public virtual void OnStopInteraction()
    {
        Debug.Log("Interaction Stopped");
        PlayerController.Instance.StoppedInteracting();
    }

    public virtual void ShowPrompt()
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
    }
}
