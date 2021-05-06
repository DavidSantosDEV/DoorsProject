using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionType
{
    DialogInteraction,
    ItemPickup,
    ItemTouch,
    PushObj,
}
public interface IInteractible
{
    AudioSource InteractionSound { get; }
    float HoldDuration { get; }
    bool HoldInteract { get; }
    bool MultipleUse { get; }
    bool IsInteractible { get; }
    public InteractionType TypeInteraction { get; }

    void OnInteract();

    void OnContinueInteract();

    void OnStopInteraction();
}
