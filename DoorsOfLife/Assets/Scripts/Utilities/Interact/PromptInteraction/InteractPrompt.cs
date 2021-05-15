using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractPrompt : IInteractibleBase
{
    TextMeshProUGUI textDisplay;

    [Header("Text Settings")]
    [SerializeField][Range(1,200)]
    private float typeSpeed=2f;
    [SerializeField]
    private string promptText="Question?";

    [Header("Audio Settings")]
    [SerializeField]
    private AudioSource myAudio;

    //bool canContinue=false;

    

    private void Start()
    {
        if (!myAudio) myAudio = gameObject.AddComponent<AudioSource>();
    }

    public override void OnInteract()
    {
        myAudio.Play();
        base.OnInteract();
    }

    public override void OnContinueInteract()
    {
        base.OnContinueInteract();
        OnStopInteraction();
    }

    public override void OnStopInteraction()
    {
        base.OnStopInteraction();
    }
    private void StartTyping() //I should have used a inheritance base...
    {
        textDisplay.text = "";
        //canContinue = false;
        StartCoroutine(nameof(Type));
    }

    private IEnumerator Type()
    {
        foreach (char letter in promptText)
        {
            textDisplay.text += letter;
            if (textDisplay.text == promptText)
            {
                //canContinue = true;
                UIManager.Instance.ShowContinueDialogueButton();
                UIManager.Instance.ShowButtonsPrompt();
            }
            yield return new WaitForSeconds(1/typeSpeed);
        }
    }
}
