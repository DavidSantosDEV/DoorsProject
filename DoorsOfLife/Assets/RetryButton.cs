using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        GameManager.Instance.ReloadScene();
        //GameManager.Instance.Openlevel(GameManager.Instance.GetCurrentScene());
        UIManager.Instance.HideGameOver();
    }
}
