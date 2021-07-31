using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElderFrog : MonoBehaviour
{
    bool key1 = false;
    bool key2 = false;
    public bool KeyOne
    {
        get => key1;
        set
        {
            key1 = value;
            CheckKeys();
        }
    }

    public bool KeyTwo
    {
        get => key2;
        set {
            key2 = value;
            CheckKeys();
            }
    }

    private SentenceSwapperGate gateSent;

    [SerializeField]
    private GameObject gate;

    private void Awake()
    {
        gateSent = GetComponent<SentenceSwapperGate>();
    }


    private void CheckKeys()
    {
        if(key1 && key2)
        {
            AllowProgress();
        }
    }

    private void AllowProgress()
    {
        gateSent.SetFree();
        Destroy(gate);
    }
}
