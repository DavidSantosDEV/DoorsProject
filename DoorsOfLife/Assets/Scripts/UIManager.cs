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

    [Header("Dialogue System")]
    [SerializeField]
    GameObject dialoguecase;
    //[SerializeField]
    //private Image Dialoguebackground = null;
    [SerializeField]
    private TextMeshProUGUI DialogueTextDisplay;
    [SerializeField]
    private TextMeshProUGUI dialogueNameText;
    [SerializeField]
    private Image dialogueAvatarImage = null;
    [SerializeField]
    private Image dialogueButtonPromptImage=null;

    [Header("Game Over screen")]
    [SerializeField]
    private GameObject gameOverCase;

    [Header("Audio Sliders")]
    [SerializeField]
    private Slider masterAudioSlider;
    [SerializeField]
    private Slider sfxAudioSlider;
    [SerializeField]
    private Slider musicAudioSlider;
    [SerializeField]
    private Slider dialogueAudioSlider;


    private EventSystem eventSystem;
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
        eventSystem = UnityEngine.EventSystems.EventSystem.current;
    }

    

    void Start()
    {

        //Hide stuff

        PromptsChange();
        HideDialogueCase();
        if (!isMainMenu)
        {
            HideInteractButton();

            HidePauseCanvas();
        }
        
    }



    public void UpdateHealth(float health, float maxHealth)
    {
        if (healthBar)
        healthBar.fillAmount = health / maxHealth;
    }

    //Show Buttons

    public void ShowInteractButton()
    {
        //imageButtonInteract.sprite = deviceInputPromptData.GetButtonInteractSprite();
        //Debug.Log(PlayerController.Instance.myInput.devices[0].name);
        imageButtonInteract.enabled = true;   
    
    }

    public void PromptsChange()
    {
        if(imageButtonInteract)
        imageButtonInteract.sprite = deviceInputPromptData.GetButtonInteractSprite();
        if(dialogueButtonPromptImage)
        dialogueButtonPromptImage.sprite = deviceInputPromptData.GetButtonInteractSprite();
    }

    public void HideInteractButton()
    {
        imageButtonInteract.enabled = false;
    }

    //Dialogue
    public TextMeshProUGUI GetDialoguetText()
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
        dialogueAvatarImage.enabled = showImage;
        dialogueNameText.enabled = showName;
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



    //Pause menu stuff

    public void HidePauseCanvas()
    {
        pauseMenuCanvas.enabled = false;
        eventSystem.enabled = false;
    }

    public void ShowPauseCanvas()
    {
        pauseMenuCanvas.enabled = true;
        eventSystem.enabled = true;
    }


    //Game Over stuff

    public void GameOverScreen()
    {
        eventSystem.SetSelectedGameObject(gameOverCase);
        eventSystem.enabled = true;
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
