using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DialogueSytem : MonoBehaviour
{
    
    private TextMeshProUGUI textDisplay=null;
    [SerializeField]
    private string[] sentences;
    [SerializeField][Range(0,0.2f)]
    private float textTypeTime=0.2f;
    [SerializeField]
    private Sprite displayAvatar;

    public Sprite AvatarImage
    {
        get => displayAvatar;
    }

    //private bool _endedDialogue=false; //Use this later so you can repeat a line, just like fromsoftware games

    //private InteractDialogue _dialogueInteractor;

    /*public InteractDialogue DialogueInteractor
    {
        get => _dialogueInteractor;
        set => _dialogueInteractor = value;
    }*/

    private bool canContinue=false;
    private int Index;

    private void Start()
    {
        textDisplay = UIManager.Instance.GetDialogueText();
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[Index].ToCharArray())
        {
            textDisplay.text += letter;
            if (textDisplay.text == sentences[Index])
            {
                canContinue = true;
            }
            yield return new WaitForSeconds(textTypeTime);
        }  
    }

    public void StartTyping()
    {
        textDisplay.text = "";
        StartCoroutine(nameof(Type));
        GameManager.Instance.GetPlayer().IsInteracting(InteractionType.DialogInteraction);
    }

    public void NextSentence()
    {
        if (canContinue)
        {
            if (Index < sentences.Length - 1)
            {
                Index++;
                textDisplay.text = "";
                StartTyping();
            }
            else
            {
                textDisplay.text = "";
                GameManager.Instance.GetPlayer().StoppedInteracting();
                //_dialogueInteractor.OnStopInteraction();
                //_endedDialogue = true;
            }
        }
    }
}
