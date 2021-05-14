using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionType
{
    DialogInteraction,
    ItemPickup,
    ItemTouch,
    OneTimeClick,
}
public interface IInteractible
{
    AudioSource InteractionSound { get; }
    bool MultipleUse { get; }
    bool IsInteractible { get; }
    public InteractionType TypeInteraction { get; }

    void OnInteract();

    void OnContinueInteract();

    void OnStopInteraction();
}
//float HoldDuration { get; }
//bool HoldInteract { get; }