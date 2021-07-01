using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonk : MonoBehaviour
{
    private PoolHandler myhandler;
    private void Awake()
    {
        myhandler = GetComponent<PoolHandler>();
    }
    public void Dispose()
    {
        myhandler.DeActivate();
    }
}
