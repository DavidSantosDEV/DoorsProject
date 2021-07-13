using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    public void ShowCredits()
    {
        UIManager.Instance.ShowCredits(obj);
    }

    public void BackCredits()
    {
        UIManager.Instance.HideCredits(obj);
    }
}
