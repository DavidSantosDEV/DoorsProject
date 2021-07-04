using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauseButton : MonoBehaviour
{
    public void UnPauseGame()
    {
        GameManager.Instance?.PauseToggle();
    }
}
