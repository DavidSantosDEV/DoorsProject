using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGate : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer rendererGateEntrance, rendererGateExit;
    [SerializeField]
    private Collider2D colEntrance, colExit;


    private bool isClosed = true;
    public bool IsClosed =>isClosed;

    private bool bossDead=false;
    public bool BossIsDead => bossDead;

    public void OnBossDeath()
    {

    }

    public void OpenGateEntrance()
    {

    }

    public void CloseGateEntrance()
    {

    }

}
