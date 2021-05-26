using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 *     public delegate void TestDelegate();

    public TestDelegate m_var;

    private void testfunc(TestDelegate func)
    {
        func();
    }

*/

[System.Serializable]
public class AudioEventsAndDialogue
{
    [SerializeField]
    private string dialogue;
    [SerializeField]
    private DialogEventBase diagEvent;
    [SerializeField]
    private AudioClip audio;

    public string Dialogue => dialogue;
    public DialogEventBase DialogueEvent => diagEvent;
    public AudioClip Audio => audio;
}

[System.Serializable]
public class StringListProgression //I considered a struct but then I couldnt do the initialization 
{
    [SerializeField]
    private bool showImage=true;
    [SerializeField]
    private bool showName=true;
    [SerializeField]
    private AudioEventsAndDialogue[] audioEventsAndDialogues;

    public bool ShowImage => showImage;
    public bool ShowName => showName;
    public AudioEventsAndDialogue[] AudioEventsDialogue => audioEventsAndDialogues;
}



public class DollNPC : IInteractibleBase
{
    private AudioSource myAudioSource = null;

    private TextMeshProUGUI textDisplay = null;
    private TextMeshProUGUI textNameDisplay = null;

    [SerializeField]
    [Range(0, 0.2f)]
    private float textTypeSpeed = 0.2f;

    [Header("Dialogue Settings")]
    [SerializeField]
    private string displaySpeakerName = "?";
    [SerializeField]
    private Sprite displayAvatar;
    //[SerializeField]
    //private string[] sentences;
    //[SerializeField]
    //DialogAndEvent[] SentencesAndEvents;

    [Header("NPC Settings")]
    [SerializeField][ShowOnly]
    private int progressionLevel=0;
    [SerializeField]
    private string nameSet = "Doll";

    [SerializeField]
    private StringListProgression[] levelAndStrings;


    private bool canContinue = false;
    private int Index;
    public int ProgressionNPC
    {
        get => progressionLevel;
        set
        {
            if (value >= 0 && !(levelAndStrings.Length<value))
            {
                progressionLevel = value;
            }
            else
            {
                progressionLevel = 0;
            }
        }
    }

    private void Awake()
    {
        isInteractible = true; //Needs to start interactible;
        myAudioSource = GetComponent<AudioSource>();

        textDisplay = UIManager.Instance.GetDialogueText();
        textNameDisplay = UIManager.Instance.GetDialogueSpeakerNameText();
    }

    public override void OnInteract()
    {
        base.OnInteract();

    }

    public override void OnContinueInteract()
    {
        base.OnContinueInteract();

    }

    public override void OnStopInteraction()
    {
        base.OnStopInteraction();
    }

    private void NextSentence()
    {
        
        if (canContinue)
        {
            if (Index < levelAndStrings[progressionLevel].AudioEventsDialogue[Index].Dialogue.Length - 1)//sentences.Length - 1)
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

    private void DisplayFullText()
    {

    }
    private void StartTyping()
    {
        textDisplay.text = "";
        canContinue = false;
        /*if (showImage)
        {
            ChangeReaction();
        }*/
        StartCoroutine(nameof(Type));
    }

    private IEnumerator Type()
    {
        if (levelAndStrings[progressionLevel].AudioEventsDialogue[Index].Audio)
        {
            if (myAudioSource)
            {
                myAudioSource.clip = levelAndStrings[progressionLevel].AudioEventsDialogue[Index].Audio;
                myAudioSource.Play();
            }
        }

        foreach (char letter in levelAndStrings[progressionLevel].AudioEventsDialogue[Index].Dialogue.ToCharArray())//sentences[Index].ToCharArray())
        {
            textDisplay.text += letter;
            if (textDisplay.text == levelAndStrings[progressionLevel].AudioEventsDialogue[Index].Dialogue)//sentences[Index])
            {
                //Check if it has event and then allow to continue
                CheckForEvent();
                canContinue = true;
                UIManager.Instance.ShowContinueDialogueButton();
            }
            yield return new WaitForSeconds(1/textTypeSpeed);
        }
    }

    private void CheckForEvent()
    {
        if (levelAndStrings[progressionLevel].AudioEventsDialogue[Index].DialogueEvent != null)
        {
            levelAndStrings[progressionLevel].AudioEventsDialogue[Index].DialogueEvent.OnActivateEvent();
        }
        /*if (SentencesAndEvents[Index].SentenceEvent != null)
        {
            SentencesAndEvents[Index].SentenceEvent.OnActivateEvent();
        }*/
    }

}
