using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class StringListProgression //I considered a struct but then I couldnt do the initialization 
{
    [SerializeField]
    private bool showImage=true;
    [SerializeField]
    private bool showName=true;
    [SerializeField]
    private string[] dialogue;

    public bool ShowImage => showImage;
    public bool ShowName => showName;

    public string[] Dialogue => dialogue;
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
    private bool showImage = true;
    [SerializeField]
    private bool showName = true;
    [SerializeField]
    private string displaySpeakerName = "?";
    [SerializeField]
    private Sprite displayAvatar;
    //[SerializeField]
    //private string[] sentences;
    [SerializeField]
    DialogAndEvent[] SentencesAndEvents;



    [Header("NPC Settings")]
    [SerializeField][ShowOnly]
    private int progressionLevel=0;
    [SerializeField]
    private string nameSet = "Doll";

    [SerializeField]
    private StringListProgression[] levelAndStrings;

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
    }

    public override void OnInteract()
    {
        base.OnInteract();

    }


}
