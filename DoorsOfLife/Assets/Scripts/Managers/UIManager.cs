using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    //
    [SerializeField]
    private bool isMainMenu=false;

    [SerializeField]
    private Canvas pauseMenuCanvas;

    [Header("Button Prompts")]
    [SerializeField]
    private Image imageButtonInteract;

    [Header("Device Display Settings")]
    public InputPromptData deviceInputPromptData;

    [Header("Health Related Stuff")]
    [SerializeField]
    private Image healthBar=null;

    [Header("General")]
    [SerializeField]
    GameObject dialoguecase;
    [SerializeField]
    GameObject dialogueStuff;
    [SerializeField]
    GameObject promptStuff;

    [Header("DialogueSystem")]
    [SerializeField]
    private TextMeshProUGUI DialogueTextDisplay;
    [SerializeField]
    private TextMeshProUGUI dialogueNameText;
    [SerializeField]
    private Image dialogueNameImg;
    [SerializeField]
    private Image avatarcaseImg,dialogueAvatarImage = null;
    [SerializeField]
    private Image dialogueButtonPromptImage=null;

    [Header("Prompt System")]
    [SerializeField]
    private GameObject promptSelectedButton;
    [SerializeField]
    private TextMeshProUGUI promptTextDisplay;

    [Header("Game Over screen")]
    [SerializeField]
    private GameObject gameOverCase;
    [SerializeField]
    private GameObject firstSelectedDeathButton;

    [Header("Audio Sliders")]
    [SerializeField]
    private Slider masterAudioSlider;
    [SerializeField]
    private Slider sfxAudioSlider;
    [SerializeField]
    private Slider musicAudioSlider;
    [SerializeField]
    private Slider dialogueAudioSlider;

    [SerializeField]
    private EventSystem eventSystemMenu, eventSystemPrompt;
    
    public static UIManager Instance { get; private set; } = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
        //eventSystemMenu = UnityEngine.EventSystems.EventSystem.current;
    }

    

    void Start()
    {

        //Hide stuff
        
        eventSystemMenu.enabled = isMainMenu;
        if(eventSystemPrompt)
        eventSystemPrompt.enabled = false;
        PromptsChange();
        HideDialogueCase();
        if (!isMainMenu)
        {
            //HideInteractButton();

            HidePauseCanvas();
        }
        
    }



    public void UpdateHealth(float health, float maxHealth)
    {
        if (healthBar)
        healthBar.fillAmount = health / maxHealth;
    }

    //Show Buttons

    /*public void ShowInteractButton()
    {
        //imageButtonInteract.sprite = deviceInputPromptData.GetButtonInteractSprite();
        //Debug.Log(PlayerController.Instance.myInput.devices[0].name);
        imageButtonInteract.enabled = true;   
    
    }*/

    public void PromptsChange()
    {
        if(imageButtonInteract)
        imageButtonInteract.sprite = deviceInputPromptData.GetButtonInteractSprite();
        if(dialogueButtonPromptImage)
        dialogueButtonPromptImage.sprite = deviceInputPromptData.GetButtonInteractSprite();
    }

    public Sprite getInteractSprite()
    {
        return deviceInputPromptData.GetButtonInteractSprite();
    }
    /*public void HideInteractButton()
    {
        imageButtonInteract.enabled = false;
    }*/

    //Dialogue
    public TextMeshProUGUI GetDialogueText()
    {
        return DialogueTextDisplay;
    }

    public TextMeshProUGUI GetDialogueSpeakerNameText()
    {
        return dialogueNameText;
    }

    public void ShowDialogueCase(bool showImage,bool showName)
    {
        dialoguecase.SetActive(true);
        dialogueStuff.SetActive(true);
        promptStuff.SetActive(false);
        dialogueAvatarImage.enabled = showImage;
        avatarcaseImg.enabled = showImage;
        dialogueNameText.enabled = showName;
        dialogueNameImg.enabled = showName;
    }

    public void ShowContinueDialogueButton()
    {
        dialogueButtonPromptImage.enabled = true;
    }

    public void HideContinueDialogueButton()
    {
        dialogueButtonPromptImage.enabled = false;
    }

    public void HideDialogueCase()
    {
        if(dialoguecase)dialoguecase.SetActive(false);
    }

    public void SetAvatarDialogue(Sprite Avatar)
    {
        dialogueAvatarImage.sprite =Avatar;
        dialogueAvatarImage.preserveAspect = true;
    }

    //Prompt stuff

    public void ShowPromptCase()
    {
        dialoguecase.SetActive(true);
        dialogueStuff.SetActive(false);
        promptStuff.SetActive(true);

        eventSystemPrompt.enabled = true;

        eventSystemMenu.SetSelectedGameObject(promptSelectedButton);
    }

    public void HidePromptCase()
    {
        eventSystemPrompt.enabled = false;
        dialoguecase.SetActive(false);
    }

    public void ShowButtonsPrompt()
    {

    }

    public TextMeshProUGUI GetPromptText()
    {
        return promptTextDisplay;
    }

    //------------------------

    //Pause menu stuff

    public void HidePauseCanvas()
    {
        pauseMenuCanvas.enabled = false;
        eventSystemMenu.enabled = false;
    }

    public void ShowPauseCanvas()
    {
        pauseMenuCanvas.enabled = true;
        eventSystemMenu.enabled = true;
    }

    [SerializeField]
    private GameObject audioStuff=null;

    public void ShowAudioStuff(GameObject button)
    {
        eventSystemMenu.SetSelectedGameObject(button);
        audioStuff.SetActive(true);
    }

    public void HideAudioStuff(GameObject button)
    {
        eventSystemMenu.SetSelectedGameObject(button);
        audioStuff.SetActive(false);
    }

    //Game Over stuff

    public void GameOverScreen()
    {
        gameOverCase.SetActive(true);
        eventSystemMenu.SetSelectedGameObject(firstSelectedDeathButton);
        eventSystemMenu.enabled = true;
    }


    //Audio Related stuff

    public void SetValuesAllVolume(float master, float sfx, float music, float dialogue)
    {
        if (masterAudioSlider) masterAudioSlider.value = Mathf.Pow(10,master/20);
        if (sfxAudioSlider) sfxAudioSlider.value = Mathf.Pow(10,sfx/20);
        if (musicAudioSlider) musicAudioSlider.value = Mathf.Pow(10,music/20);
        if (dialogueAudioSlider) dialogueAudioSlider.value = Mathf.Pow(10,dialogue/20);
    }
}
