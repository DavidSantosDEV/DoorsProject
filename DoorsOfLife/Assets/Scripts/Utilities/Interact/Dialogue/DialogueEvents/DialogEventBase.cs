using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event Data", menuName = "DialogEvent/DialogEventData")]
public class DialogEventBase: ScriptableObject
{
    public virtual void OnActivateEvent()
    {
        Debug.Log("Event Activated: ");
    }
}
