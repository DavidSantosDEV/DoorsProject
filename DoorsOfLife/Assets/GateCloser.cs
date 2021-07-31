using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCloser : MonoBehaviour
{
    [SerializeField]
    private BossGate myGate;

    [SerializeField]
    private EnemyHearts enH;

    [SerializeField]
    private string strTag = "Player";

    private void Start()
    {
        myGate.AddChild(this);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(strTag))
        {
            if (myGate)
            {
                if (!myGate.IsClosed && !myGate.BossIsDead)
                {
                    enH.Heal(enH.MaxHealth);
                    myGate.CloseGateEntrance();
                }
            }
        }
    }
}
