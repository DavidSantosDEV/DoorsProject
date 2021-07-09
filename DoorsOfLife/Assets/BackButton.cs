using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    public void BackButtonAudio()
    {
        UIManager.Instance.HideAudioStuff(obj);
    }
}
