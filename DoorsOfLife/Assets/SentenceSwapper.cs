using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueData //Weird unity doesnt allow twodimensional arrays to be serialized
{
    public DialogueAndEvent[] dialog;
}

public class SentenceSwapper : MonoBehaviour
{
    [SerializeField]
    protected bool returnOriginal = true;

    [SerializeField]
    protected DialogueData[] newOnes;

    [SerializeField]
    protected InteractDialogue objectOfSwap;

    protected DialogueAndEvent[] original;

    protected int times=0;

    protected bool stopSwitching = false;

    public bool StopSwitching
    {
        get => stopSwitching;
        set => stopSwitching = value;
    }

    private void Start()
    {
        original = objectOfSwap.GetSentences();
        objectOfSwap.OnInteractionStopped += Activate;
    }

    protected virtual void Activate()
    {
        if (stopSwitching) return;
        times++;
        SwapSentences(times-1);
        
    }

    public void SwapSentences(int index)
    {
        if (newOnes.Length > index)
        {
            objectOfSwap.SwapSentences(newOnes[index].dialog);
        }
        else
        {
            if (returnOriginal)
            {
                ReturnOriginals();
                times = 0;
            }
            else
            {
                if (!(newOnes.Length - 1 < 0))
                {
                    objectOfSwap.SwapSentences(newOnes[newOnes.Length - 1].dialog);
                }
                
            }

        }
    }

    public void ReturnOriginals()
    {
        objectOfSwap.SwapSentences(original);
    }
}
