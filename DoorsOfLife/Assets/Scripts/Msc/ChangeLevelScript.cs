using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevelScript : MonoBehaviour
{
    [SerializeField]
    private int level=0;

    public void ChangeLevel()
    {
        GameManager.Instance.Openlevel(level);
    }
}
