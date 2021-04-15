using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEventBase: MonoBehaviour
{
    public virtual void OnActivateEvent()
    {
        Debug.Log("Event Activated:" + gameObject.name);
    }
}
