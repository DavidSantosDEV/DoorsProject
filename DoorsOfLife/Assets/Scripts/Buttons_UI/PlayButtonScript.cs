using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonScript : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.Openlevel(1);
    }
}
