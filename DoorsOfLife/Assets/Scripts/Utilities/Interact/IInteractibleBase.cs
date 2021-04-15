using System.Collections;
using System.Collections.Generic;
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


    public AudioSource InteractionSound => interactionSound;
    public float HoldDuration => holdDuration;
    public bool HoldInteract => holdInteract;
    public bool MultipleUse => multipleUse;
    public bool IsInteractible => isInteractible;
    public InteractionType TypeInteraction=>typeInteraction;

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
}
