using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorInteractible : IInteractibleBase
{
    [SerializeField]
    bool IsLocked = true;

    [SerializeField]
    private bool usesKey = true;

    [SerializeField]
    private DoorsAndNumbers myKey;

    [SerializeField]
    private string doorIsClosed="This door is closed.", doorOpens="Door is open.";
    string SentencetoType;

    [SerializeField]
    private Sprite spriteOpen, spriteClosed;

    [SerializeField][Range(1,float.MaxValue)]
    private float typeSpeed=20;

    [SerializeField]
    AudioClip openSound, closedSound;

    bool isFinished=false;

    private TextMeshProUGUI textDisplay = null;

    private SpriteRenderer mySpriteRenderer;
    private Collider2D myCol;
    private AudioSource myAudioSource;

    private void Start()
    {
        myCol = GetComponent<Collider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAudioSource = GetComponent<AudioSource>();
        if (myAudioSource) myAudioSource = gameObject.AddComponent<AudioSource>();

        textDisplay = UIManager.Instance.GetDialogueText();
        if (!textDisplay) Debug.Log("null text");
    }

    public override void OnInteract()
    {
        base.OnInteract();
        Debug.Log("Nice cock bro");
        if (IsLocked)
        {
            if (GameManager.Instance.GetKey(myKey) && usesKey)
            {
                OpenDoor();
            }
            else
            {
                PlaySound(closedSound);
                StartTyping(doorIsClosed);
            }
        }
        else
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        mySpriteRenderer.sprite = spriteOpen;
        IsLocked = false;
        PlaySound(openSound);
        StartTyping(doorOpens);
    }

    public void OpenDoorNoKey()
    {
        mySpriteRenderer.sprite = spriteOpen;
        IsLocked = false;
        PlaySound(openSound);
        PlayerController player = GameManager.Instance.GetPlayer();
        player.inCutscene = true;
        player.interactionData.ResetData();
        player.interactionData.Interactible = this;
        //player.IsInteracting(typeInteraction);
        StartTyping(doorOpens);
    }


    public override void OnContinueInteract()
    {
        base.OnContinueInteract();
        if (isFinished)
        {
            OnStopInteraction();
        }
        else
        {
            DisplayFullText();
        }
        
    }

    public override void OnStopInteraction()
    {
        base.OnStopInteraction();
        UIManager.Instance.HideDialogueCase();
        if (IsLocked==false/*isOpen*/)
        {
            Debug.Log("Am OPEN");
            isInteractible = false;
            Destroy(myCol); //Why would I need this collider anymore
        }
        GameManager.Instance.GetPlayer().inCutscene = false;
    }

    private void PlaySound(AudioClip clip) //ease of use stuff
    {
        myAudioSource.clip = clip;
        myAudioSource.Play();
    }

    private void StartTyping(string sentence)
    {
        textDisplay.text = "";
        SentencetoType = sentence;
        UIManager.Instance.ShowDialogueCase(false,false);
        StartCoroutine(nameof(Type));
    }

    IEnumerator Type()
    {
        foreach (char letter in SentencetoType.ToCharArray())
        {
            textDisplay.text += letter;
            if (textDisplay.text == SentencetoType)
            {
                isFinished = true;
                UIManager.Instance.ShowContinueDialogueButton();
            }
            yield return new WaitForSeconds(1/typeSpeed);
        }
    }
    private void DisplayFullText()
    {
        StopCoroutine(nameof(Type));
        textDisplay.text = SentencetoType;
        isFinished = true;
        UIManager.Instance.ShowContinueDialogueButton();
    }
}
