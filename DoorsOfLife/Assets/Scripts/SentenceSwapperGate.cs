using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentenceSwapperGate : SentenceSwapper
{
    [SerializeField]
    private DialogueData[] freeOnes;

    private bool isDealt = false;

    public void SetFree()
    {
        isDealt = true;
        times = 0;
    }

    protected override void Activate()
    {
        if (isDealt)
        {
            times++;
            SwapSentencesFree(times);
        }
        else
        {
            base.Activate();
        }
    }

    public void SwapSentencesFree(int index)
    {
        if (freeOnes.Length > index)
        {
            objectOfSwap.SwapSentences(freeOnes[index].dialog);
        }
        else
        {
            if (returnOriginal)
            {
                ReturnOriginalFreeOnes();
                times = 0;
            }
            else
            {
                objectOfSwap.SwapSentences(freeOnes[freeOnes.Length - 1].dialog);
            }

        }
    }

    private void ReturnOriginalFreeOnes()
    {
        objectOfSwap.SwapSentences(freeOnes[0].dialog);
    }
}
