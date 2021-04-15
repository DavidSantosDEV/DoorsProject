using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Interaction Data",menuName ="InteractionSystem/InteractionData")]
public class InteractionData : ScriptableObject
{
    private IInteractibleBase myInteractible;

    public IInteractibleBase Interactible
    {
        get => myInteractible;
        set => myInteractible = value;
    }

    public void Interact()
    {
        if (myInteractible.IsInteractible)
        {
            myInteractible.OnInteract();
            //ResetData();
        }
    }

    public void ContinueInteract()
    {
        if (myInteractible.IsInteractible)
        {
            myInteractible.OnContinueInteract();
        }
    }

    public bool IsSameInteractible(IInteractibleBase newInteractible)
    {
        return myInteractible == newInteractible;
    }

    public bool IsEmpty()
    {
        return myInteractible == null;
    }

    public void ResetData()
    {
        myInteractible = null;
    }

    public InteractionType GetTypeOfInteraction()
    {
        return myInteractible.TypeInteraction;
    }
}
