using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;  
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public enum CharacterReactions{
    Happy,
    Sweat,
    Normal,
}

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject parentUIObject;
    [SerializeField]
    private GameObject MainMenuCanvas;
    [SerializeField]
    private GameObject GameplayCanvas;
    [SerializeField]
    private GameObject PauseCanvas;
    [SerializeField]
    private GameObject LoadingCanvas;
    [SerializeField]
    private GameObject GameOverCanvas;


    [Header("Main Menu Stuff")]
    [SerializeField]
    private EventSystem eventSystemMenu;
    [SerializeField]
    private GameObject creditsObject;

    [Header("Pause Menu")]
    [SerializeField]
    private Image heartPauseImage;
    [SerializeField]
    private Sprite[] imagesHeartFill;



    [Header("Button Prompts")]
    [SerializeField]
    private Image imageButtonInteract;

    [Header("Device Display Settings")]
    public InputPromptData deviceInputPromptData;

    [Header("Gameplay")]
    [SerializeField]
    private VerticalLayoutGroup heartContainer;
    [SerializeField]
    private GameObject textShard;

    [Header("DialogueSystem")]
    [SerializeField]
    GameObject dialoguecase;
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

    [Header("Game Over screen")]
    [SerializeField]
    private GameObject firstSelectedDeathButton;


    [Header("Audio Sliders")]
    [SerializeField]
    private GameObject audioStuff = null;
    [SerializeField]
    private Slider masterAudioSlider;
    [SerializeField]
    private Slider sfxAudioSlider;
    [SerializeField]
    private Slider musicAudioSlider;
    [SerializeField]
    private Slider dialogueAudioSlider;

    [Header("Visual Settings")]
    [SerializeField]
    private TMP_Dropdown resolutionsDrop;


    public static UIManager Instance { get; private set; } = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            CustomSettup();
        }
        else
        {
            Destroy(gameObject);
        }

        if(resolutionsDrop)
        resolutionsDrop.ClearOptions();

        Resolution[] resolutions = Screen.resolutions;
        
        List<string> options = new List<string>();
        Screen.resolutions.ToList().ForEach(res => options.Add(res.ToString()));

        if (resolutionsDrop)
        {
            resolutionsDrop.AddOptions(options);

            resolutionsDrop.value = Screen.resolutions.ToList().IndexOf(Screen.currentResolution);
        }      
    }
    private void CustomSettup()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(parentUIObject);
    }

    //Menu Stuff

    public void ShowMenuStuff()
    {
        MainMenuCanvas.SetActive(true);
    }

    public void HideMenuStuff()
    {
        MainMenuCanvas.SetActive(false);
    }

    //Gameplay Stuff

    public VerticalLayoutGroup GetHeartContainerPlayer()
    {
        return heartContainer;
    }

    public void ShowGameplayStuff()
    {
        GameplayCanvas.SetActive(true);
    }

    public void HideGameplayStuff()
    {
        GameplayCanvas.SetActive(false);
    }

    //Loading Screen
    public void ShowLoadingScreen()
    {
        LoadingCanvas.SetActive(true);
    }

    public void HideLoadingScreen()
    {
        LoadingCanvas.SetActive(false);
    }
    //-----

    //Credits
    public void ShowCredits(GameObject button)
    {
        if (audioStuff.activeSelf)
        {
            audioStuff.SetActive(false);
        }
        eventSystemMenu.SetSelectedGameObject(button);
        creditsObject.SetActive(true);
    }

    public void HideCredits(GameObject button)
    {
        eventSystemMenu.SetSelectedGameObject(button);
        creditsObject.SetActive(false);
    }
    //-----------


    private int progressionHeart = 0;
    public void UpgradeMenuHeart()
    {
        progressionHeart++;
        if (progressionHeart <= imagesHeartFill.Length - 1)
        {
            heartPauseImage.sprite = imagesHeartFill[progressionHeart];
            StartCoroutine(flashNewShard());
        }
    }

    private IEnumerator flashNewShard()
    {
        textShard.SetActive(true);
        yield return new WaitForSeconds(2);
        textShard.SetActive(false);

    }

    private void Update() //I DO NOT LIKE THIS ONE BIT BUT UNITY FORCED MY HAND eventsystem.lastselectedgameobject is obsolete!
    {
        if (eventSystemMenu.currentSelectedGameObject != currentgObj)
        {
            lastSelectedGameObj = currentgObj;

            currentgObj = eventSystemMenu.currentSelectedGameObject;
        }
    }

    private GameObject currentgObj;
    private GameObject lastSelectedGameObj;

    public void SelectMenuStuff(bool cursor)
    {
        if (!cursor)
        {
            if (lastSelectedGameObj)
            {
                eventSystemMenu.SetSelectedGameObject(lastSelectedGameObj);
            }
            else
            {
                eventSystemMenu.SetSelectedGameObject(currentgObj);
            }
            
        }
        else
        {

            Cursor.visible = GameManager.Instance.GameIsPaused;

            GameObject obj =  eventSystemMenu.currentSelectedGameObject != null ? eventSystemMenu.currentSelectedGameObject :  eventSystemMenu.firstSelectedGameObject;
            if (obj)
            {
                Selectable btn = (obj.GetComponent<Selectable>());
                btn?.OnDeselect(new BaseEventData(eventSystemMenu));
                eventSystemMenu.SetSelectedGameObject(null);
            }

        }
    }

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
        dialogueAvatarImage.sprite = Avatar;
        dialogueAvatarImage.preserveAspect = true;
    }

    //Pause menu stuff

    public void HidePauseCanvas()
    {
        PauseCanvas.SetActive(false);
    }

    public void ShowPauseCanvas()
    {
        PauseCanvas.SetActive(true);
    }


    public void ShowAudioStuff(GameObject button)
    {
        if (creditsObject.activeSelf)
        {
            creditsObject.SetActive(false);
        }
        eventSystemMenu.SetSelectedGameObject(button);
        audioStuff.SetActive(true);
    }

    public void HideAudioStuff(GameObject button)
    {
        eventSystemMenu.SetSelectedGameObject(button);
        audioStuff.SetActive(false);
    }

    //Game Over stuff

    public void ShowGameOver()
    {
        GameOverCanvas.SetActive(true);
        eventSystemMenu.SetSelectedGameObject(firstSelectedDeathButton);
        //eventSystemMenu.enabled = true;
    }

    public void HideGameOver()
    {
        GameOverCanvas.SetActive(false);
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
