using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    public void ShowOptions(GameObject select)
    {
        UIManager.Instance.ShowAudioStuff(select);
    }
}
