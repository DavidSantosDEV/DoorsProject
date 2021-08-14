using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
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

    [SerializeField]
    private UnityEvent bossDeathEvent;

    private bool isClosed = true;
    public bool IsClosed =>isClosed;

    private bool bossDead=false;
    public bool BossIsDead => bossDead;

    private List<GateCloser> mychild= new List<GateCloser>();

    [SerializeField]
    private GameObject tedy;
    public void AddChild(GateCloser c)
    {
        mychild.Add(c);
    }

    public void OnBossDeath()
    {
        bossDeathEvent?.Invoke();
        bossDead = true;
        //OpenGateEntrance();

        //rendererGateExit.sprite = openGate;



        tedy.SetActive(true);

        foreach(GateCloser c in mychild)
        {
            Destroy(c);
        }
    }

    public void OpenGateEntrance()
    {
        isClosed = false;
        rendererGateEntrance.sprite = openGate;
        colEntrance.isTrigger = true;
    }

    public void CloseGateEntrance()
    {
        rendererGateEntrance.sprite = closedGate;
        colEntrance.isTrigger = false;
    }

}
