using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGiveItem : DialogEventBase
{
    [SerializeField]
    private GameObject objectToGive;
    public override void OnActivateEvent()
    {
        base.OnActivateEvent();
        Debug.Log("Object Given: " + objectToGive.name);
        Debug.Log("Event Activated");
    }
}
