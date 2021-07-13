using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;  
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;
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
    private GameObject playerInputMenuPrefab;
    [SerializeField]
    private GameObject prefabEventSystem;


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
    private GameObject firstButtonMenu;
    [SerializeField]
    private GameObject firstButtonGameplay;
    [SerializeField]
    private EventSystem eventSystemUI;
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

    private void Start()
    {
        PromptsChange();
    }

    private void CustomSettup()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(parentUIObject);
    }

    public void FindNewEventSystem()
    {
        eventSystemUI = Instantiate(prefabEventSystem).GetComponent<EventSystem>(); //FindObjectOfType<EventSystem>(); //Okay let me go into detail how utterly retarded unity can be, I have to create a new event system for EVERY scene i have in game.
        //                                                  Why you ask?? Well simple unity does not recognize that this event system works everytime a scene is changed, so, great, I have to do this retarded mess
        if(GameManager.Instance.GetCurrentScene()==0)
        Instantiate(playerInputMenuPrefab);
    }

    //Settup changes between Gameplay etc

    public void SettupGameplay()
    {
        //eventSystemUI.firstSelectedGameObject = firstButtonGameplay;
        SelectButton(firstButtonGameplay);
        //eventSystemUI.SetSelectedGameObject(firstButtonGameplay);
        eventSystemUI.enabled = false;
    }

    public void SettupMenu()
    {
        //eventSystemUI.firstSelectedGameObject = firstButtonMenu;
        SelectButton(firstButtonMenu);
        //eventSystemUI.SetSelectedGameObject(firstButtonMenu);
        eventSystemUI.enabled = true;

        //ResetInput();
    }

    /*private void ResetInput()
    {
        inputPlayer = FindObjectOfType<PlayerInput>();
        inputPlayer.enabled = false;
        Debug.Log(inputPlayer);

        Debug.Log(inputPlayer);
        inputPlayer.enabled = true;
    }*/

    //


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
        eventSystemUI.SetSelectedGameObject(button);
        creditsObject.SetActive(true);
    }

    public void HideCredits(GameObject button)
    {
        eventSystemUI.SetSelectedGameObject(button);
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

    public void UpdatePortraitPain()
    {

    }

    public void UpdatePortraitNormal()
    {

    }

    private void Update() //I DO NOT LIKE THIS ONE BIT BUT UNITY FORCED MY HAND eventsystem.lastselectedgameobject is obsolete!
    {
        if (eventSystemUI.currentSelectedGameObject != currentgObj)
        {
            lastSelectedGameObj = currentgObj;

            currentgObj = eventSystemUI.currentSelectedGameObject;
            Debug.Log(currentgObj);
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
                eventSystemUI.SetSelectedGameObject(lastSelectedGameObj);
            }
            else
            {
                if (currentgObj == null)
                {
                    if (GameManager.Instance)
                    {
                        if (GameManager.Instance.GetCurrentScene() == 0)
                        {
                            SelectButton(firstButtonMenu);
                            //eventSystemUI.SetSelectedGameObject(firstButtonMenu);
                        }
                        else
                        {
                            SelectButton(firstButtonGameplay);
                            //eventSystemUI.SetSelectedGameObject(firstButtonGameplay);
                        }
                    }
                    else
                    {
                        SelectButton(firstButtonMenu);
                        //eventSystemUI.SetSelectedGameObject(firstButtonMenu);
                    }
                }
                else
                {
                    SelectButton(currentgObj);
                    //eventSystemUI.SetSelectedGameObject(currentgObj);
                }
            }
            
        }
        else
        {

            Cursor.visible = GameManager.Instance.GameIsPaused || (GameManager.Instance.GetCurrentScene() == 0);

            GameObject obj =  eventSystemUI.currentSelectedGameObject != null ? eventSystemUI.currentSelectedGameObject :  eventSystemUI.firstSelectedGameObject;
            if (obj)
            {
                Selectable btn = (obj.GetComponent<Selectable>());
                btn?.OnDeselect(new BaseEventData(eventSystemUI));
                eventSystemUI.SetSelectedGameObject(null);
            }

        }
    }

    private void SelectButton(GameObject button)
    {
        StartCoroutine(SelectionRoutine(button));
    }

    private IEnumerator SelectionRoutine(GameObject obj)
    {
        eventSystemUI.SetSelectedGameObject(null);
        yield return null;
        eventSystemUI.SetSelectedGameObject(obj);
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
        eventSystemUI.enabled = false;

    }

    public void ShowPauseCanvas()
    {
        PauseCanvas.SetActive(true);
        eventSystemUI.SetSelectedGameObject(firstButtonGameplay);
        eventSystemUI.enabled = true;
    }


    public void ShowAudioStuff(GameObject button)
    {
        if (creditsObject.activeSelf)
        {
            creditsObject.SetActive(false);
        }
        eventSystemUI.SetSelectedGameObject(button);
        audioStuff.SetActive(true);
    }

    public void HideAudioStuff(GameObject button)
    {
        eventSystemUI.SetSelectedGameObject(button);
        audioStuff.SetActive(false);
    }

    //Game Over stuff

    public void ShowGameOver()
    {
        GameOverCanvas.SetActive(true);
        eventSystemUI.SetSelectedGameObject(firstSelectedDeathButton);
        eventSystemUI.enabled = true;
        Cursor.visible = true;
    }

    public void HideGameOver()
    {
        Cursor.visible = false;
        eventSystemUI.enabled = false;
        GameOverCanvas.SetActive(false);
    }


    //Audio Related stuff

    public void SetValuesAllVolume(float master, float sfx, float music)
    {
        float temp = Mathf.Clamp(Mathf.Pow(10, master / 20), masterAudioSlider.minValue, masterAudioSlider.maxValue);
        //masterAudioSlider.value = temp;

        masterAudioSlider?.SetValueWithoutNotify(temp);
        sfxAudioSlider?.SetValueWithoutNotify(Mathf.Clamp(Mathf.Pow(10, sfx / 20), sfxAudioSlider.minValue, sfxAudioSlider.maxValue));
        
        musicAudioSlider?.SetValueWithoutNotify(Mathf.Clamp(Mathf.Pow(10,music/20),musicAudioSlider.minValue,musicAudioSlider.maxValue));
    }
}
