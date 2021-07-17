using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractDialogue : IInteractibleBase
{

    private AudioSource myAudioSource = null;

    private TextMeshProUGUI textDisplay = null;
    private TextMeshProUGUI textNameDisplay = null;

    private float textTypeSpeed;

    [Header("Dialogue Settings")]
    [SerializeField]
    private bool showImage = true;
    [SerializeField]
    private bool showName=true;
    [SerializeField]
    private string displaySpeakerName="?";
    [SerializeField]
    private Sprite displayAvatar;
    //[SerializeField]
    //private string[] sentences;
    [SerializeField]
    DialogAndEvent[] SentencesAndEvents;


    [Header("Reaction Display")]
    public Sprite happySprite;
    public Sprite sadSprite;
    public Sprite angrySprite;

    //private bool _endedDialogue = false; //Use this later so you can repeat a line, just like fromsoftware games
    private bool canContinue = false;
    private int Index;

    private void Start()
    {
        textTypeSpeed = GameManager.Instance!=null ?  GameManager.Instance.TextSpeed : 4;
        myAudioSource = GetComponent<AudioSource>();
        typeInteraction = InteractionType.DialogInteraction;
        textDisplay = UIManager.Instance?.GetDialogueText();

        if(showName)
        textNameDisplay = UIManager.Instance?.GetDialogueSpeakerNameText();
    }

    public override void OnInteract()
    {
        base.OnInteract();
        Debug.Log("Dialog Start");
        UIManager.Instance.SetAvatarDialogue(displayAvatar);
        UIManager.Instance.ShowDialogueCase(showImage,showName);
        if(showName)
        textNameDisplay.text = displaySpeakerName;
        StartTyping();
    }
    public override void OnContinueInteract()
    {
        base.OnContinueInteract();
        NextSentence();
    }

    public override void OnStopInteraction()
    {
        base.OnStopInteraction();
        UIManager.Instance.HideDialogueCase();
        Index = 0;
        canContinue = false;
        if(GameManager.Instance.GetPlayer().inCutscene == true)
        {
            GameManager.Instance.GetPlayer().inCutscene =false;
        }
    }

    public void SwapAvatar(Sprite avatar)
    {
        UIManager.Instance.SetAvatarDialogue(avatar);
    }

    public void SwapDisplayName(string name)
    {
        textNameDisplay.text = name;
    }

    // Dialogue Related stuff

    private IEnumerator Type()
    {
        CheckForEvent();
        if (SentencesAndEvents[Index].sound)
        {
            if (myAudioSource)
            {
                myAudioSource.clip = SentencesAndEvents[Index].sound;
                myAudioSource.Play();
            } 
        }
        
        foreach (char letter in SentencesAndEvents[Index].Sentence.ToCharArray())//sentences[Index].ToCharArray())
        {
            textDisplay.text += letter;
            if (textDisplay.text == SentencesAndEvents[Index].Sentence)//sentences[Index])
            {
                //Check if it has event and then allow to continue
                canContinue = true;
                UIManager.Instance.ShowContinueDialogueButton();
            }
            yield return new WaitForSeconds(1/textTypeSpeed);
        }
    }

    private void StartTyping()
    {
        textDisplay.text = "";
        canContinue = false;
        if (showImage)
        {
            ChangeReaction();
        }     
        StartCoroutine(nameof(Type));
    }

    private void NextSentence()
    {
        if (canContinue)
        {
            if (Index < SentencesAndEvents.Length-1)//sentences.Length - 1)
            {
                Index++;
                textDisplay.text = "";
                StartTyping();
                UIManager.Instance.HideContinueDialogueButton();
            }
            else
            {
                textDisplay.text = "";
                if (myAudioSource)
                {
                    myAudioSource.Stop();
                }
                
                OnStopInteraction();
                //_endedDialogue = true;
            }
        }
        else
        {
            DisplayFullText();
            UIManager.Instance.ShowContinueDialogueButton();
        }
    }

    private void ResetIndex()
    {
        Index = 0;
    }

    private void DisplayFullText()
    {
        StopCoroutine(nameof(Type));
        textDisplay.text = SentencesAndEvents[Index].Sentence; //sentences[Index];
        //CheckForEvent();
        canContinue = true;
    }

    private void CheckForEvent()
    {
        if (SentencesAndEvents[Index].SentenceEvent != null)
        {
            SentencesAndEvents[Index].SentenceEvent.Invoke();//OnActivateEvent();
        }
    }

    public void AssignSpeakerName(string name)
    {
        displaySpeakerName = name;
        //update text
    }

    public void SwapSentences(DialogAndEvent[] newS)
    {
        SentencesAndEvents = newS;
    }

    public void StartShowImage()
    {
        showImage = true;
        UIManager.Instance.ShowDialogueCase(showImage, showName);
    }

    public void StartShowName()
    {
        showName = true;
        UIManager.Instance.ShowDialogueCase(showImage, showName);
    }

    private void ChangeReaction()
    {
        switch (SentencesAndEvents[Index].reaction)
        {
            case CharacterReaction.Normal:
                UIManager.Instance.SetAvatarDialogue(displayAvatar);
                break;

            case CharacterReaction.Happy:
                UIManager.Instance.SetAvatarDialogue(happySprite);
                break;
            case CharacterReaction.Angry:
                UIManager.Instance.SetAvatarDialogue(angrySprite);
                break;

            case CharacterReaction.Sad:
                UIManager.Instance.SetAvatarDialogue(sadSprite);
                break;
        }
    }
}
