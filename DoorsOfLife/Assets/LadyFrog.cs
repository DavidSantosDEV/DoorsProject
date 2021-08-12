using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyFrog : MonoBehaviour
{
    private SentenceSwapperGate mySwapper;
    private InteractDialogue myDiag;

    [SerializeField]
    private DialogueAndEvent[] newD;

    private void Awake()
    {
        mySwapper = GetComponent<SentenceSwapperGate>();
        myDiag = GetComponent<InteractDialogue>();
    }
    public void ChangeDialog() //Yes this is all because I didnt make the Sentence Swapper with an array, I know its dumb
    {
        Destroy(mySwapper);
        myDiag.SwapSentences(newD);
    }
}
