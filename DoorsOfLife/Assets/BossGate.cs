using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGate : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer rendererGateEntrance, rendererGateExit;
    [SerializeField]
    private Collider2D colEntrance, colExit;

    [SerializeField]
    private Sprite openGate;
    [SerializeField]
    private Sprite closedGate;

    private bool isClosed = true;
    public bool IsClosed =>isClosed;

    private bool bossDead=false;
    public bool BossIsDead => bossDead;

    public void OnBossDeath()
    {

    }

    public void OpenGateEntrance()
    {
        rendererGateEntrance.sprite = openGate;
        colEntrance.isTrigger = true;
    }

    public void CloseGateEntrance()
    {
        rendererGateEntrance.sprite = closedGate;
        colEntrance.isTrigger = false;
    }

}
