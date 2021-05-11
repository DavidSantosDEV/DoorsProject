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
        set
        {

            if(myInteractible)
            myInteractible.HidePrompt(); //Clear previous value

            myInteractible = value;
            myInteractible.ShowPrompt(); // Show new value
        }
    }

    public void Interact()
    {
        if (myInteractible.IsInteractible)
        {
            myInteractible.OnInteract();
            myInteractible.HidePrompt();
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
        if(myInteractible)
        myInteractible.HidePrompt();

        //Debug.Log(myInteractible);

        myInteractible = null;
    }

    public InteractionType GetTypeOfInteraction()
    {
        return myInteractible.TypeInteraction;
    }

    public void ControlsChanged()
    {
        if (myInteractible)
        {
            myInteractible.ChangePrompt(UIManager.Instance.getInteractSprite());
        }
    }
}
