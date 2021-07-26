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
    private DialogueData[] newOnes;

    [SerializeField]
    private InteractDialogue objectOfSwap;

    private DialogueAndEvent[] original;

    private int times=0;


    private void Start()
    {
        original = objectOfSwap.GetSentences();
        objectOfSwap.OnInteractionStopped += Activate;
    }

    private void Activate()
    {
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
            ReturnOriginals();
            times = 0;
        }
    }

    public void ReturnOriginals()
    {
        objectOfSwap.SwapSentences(original);
    }
}
