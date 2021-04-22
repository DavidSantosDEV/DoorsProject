using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractDialogue : IInteractibleBase
{

    private AudioSource myAudioSource = null;

    private TextMeshProUGUI textDisplay = null;
    private TextMeshProUGUI textNameDisplay = null;
    [SerializeField]
    [Range(0, 0.2f)]
    private float textTypeTime = 0.2f;

    [Header("Dialogue Settings")]
    [SerializeField]
    private bool showImage=true;
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


    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        typeInteraction = InteractionType.DialogInteraction;
        textDisplay = UIManager.Instance.GetDialoguetText();

        textNameDisplay = UIManager.Instance.GetDialogueSpeakerNameText();
    }

    public override void OnInteract()
    {
        base.OnInteract();
        Debug.Log("Dialog Start");
        UIManager.Instance.SetAvatarDialogue(displayAvatar);
        UIManager.Instance.ShowDialogueCase(showImage);
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
    }


    // Dialogue Related stuff

    private IEnumerator Type()
    {
        if (SentencesAndEvents[Index].sound)
        {
            myAudioSource.clip = SentencesAndEvents[Index].sound;
            myAudioSource.Play();
        }
        
        foreach (char letter in SentencesAndEvents[Index].Sentence.ToCharArray())//sentences[Index].ToCharArray())
        {
            textDisplay.text += letter;
            if (textDisplay.text == SentencesAndEvents[Index].Sentence)//sentences[Index])
            {
                //Check if it has event and then allow to continue
                CheckForEvent();
                canContinue = true;
                UIManager.Instance.ShowContinueDialogueButton();
            }
            yield return new WaitForSeconds(textTypeTime);
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
                myAudioSource.Stop();
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

    private void ShowButton()
    {
        //call ui manager
    }

    private void ResetIndex()
    {
        Index = 0;
    }

    private void DisplayFullText()
    {
        StopCoroutine(nameof(Type));
        textDisplay.text = SentencesAndEvents[Index].Sentence; //sentences[Index];
        CheckForEvent();
        canContinue = true;
    }

    private void CheckForEvent()
    {
        if (SentencesAndEvents[Index].SentenceEvent != null)
        {
            SentencesAndEvents[Index].SentenceEvent.OnActivateEvent();
        }
    }

    public void AssignSpeakerName(string name)
    {
        displaySpeakerName = name;
        //update text
    }

    private void ChangeReaction()
    {
        switch (SentencesAndEvents[Index].reaction)
        {
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
