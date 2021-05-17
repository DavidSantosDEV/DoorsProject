using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public enum DoorsAndNumbers : int
{
    HouseDoor = 0,
    GardenDoor = 1
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private bool LockFPS=false;
    [SerializeField][Range(30, 144)]
    private int lockedFPS = 60;

    public SoundBasics soundSet;

    [Header("Key related stuff")]
    public bool[] key = new bool[2];

    private bool gamepaused=false;

    public bool GameIsPaused => gamepaused;

    public static GameManager Instance { get; private set; } = null;

    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.visible = false;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (LockFPS)
        {
            Application.targetFrameRate = lockedFPS;
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    void Start()
    {
        SetAudioPrevious();
    }

    private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {

    }
    //Frame counting

    float deltaTime = 0.0f; // <- DEBUG ONLY

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }
    void OnGUI()
    {
        if (!Debug.isDebugBuild) return;
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = Color.white;//new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }

    #region KeysForDoors

    public bool GetKey(DoorsAndNumbers door)
    {
        return key[(int)door];
    }

    public void SetKey(DoorsAndNumbers door,bool val)
    {
        key[ (int) door] = val;
    }

    #endregion


    #region Pause and Game Over

    public void PauseToggle()
    {
        if (Time.timeScale == 0)
        {
            UnPauseGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame() //Find way to pause sounds
    {
        Time.timeScale = 0;
        //soundSet.
        gamepaused = true;
        UIManager.Instance.ShowPauseCanvas();
        player.EnableMenuControls();
    }

    private void UnPauseGame()
    {
        Time.timeScale = 1;
        gamepaused = false;
        UIManager.Instance.HidePauseCanvas();
        player.EnableGameplayControls();
    }

    private void PauseGameNoCanvas()
    {
        Time.timeScale = 0;
        gamepaused = true;
    }

    public void ShowGameOver()
    {
        PauseGameNoCanvas();
        UIManager.Instance.GameOverScreen();
        Debug.Log("Game Over");
        //ChangeToMenu();
    }

    #endregion

    #region Level Changing 

    /*private IEnumerator UnloadPreviousScene(int sceneIndex)
    {
        Scene unload = SceneManager.GetActiveScene();
        AsyncOperation unloadprocess = SceneManager.UnloadSceneAsync(unload);
        while(!unloadprocess.isDone){
            Debug.Log(unloadprocess.progress);
            yield return null;
        }
        yield return null;
        StartCoroutine(LoadScene(sceneIndex));
    }*/

    private IEnumerator LoadScene(int level)
    {
        //Scene previousScene = SceneManager.GetActiveScene();
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(level);
        while (!sceneLoading.isDone)
        {
            Debug.Log("Progress: " + sceneLoading.progress);
            yield return null;
        }
        Debug.Log("Scene Loaded");
        yield return null;
        
    }

    public void ChangeToLevel()
    {
        //GameManager.
        if(Time.timeScale==0) UnPauseGame();
        StartCoroutine(LoadScene(1));
    }

    public void ChangeToMenu()
    {
        if (Time.timeScale == 0) UnPauseGame();
        
        StartCoroutine(LoadScene(0));
        //StartCoroutine(LoadLevel(0));
    }

    /*private void LoadScene(int sceneIndex)
    {
        StartCoroutine(UnloadPreviousSceneAndLoadNext(sceneIndex));
    }*/

    

    #endregion

    public void CloseGame()
    {
        Application.Quit();
    }





    //AUDIO STUFF HERE

    private void SetAudioPrevious()
    {
        soundSet.RestorePreviousValues();
    }

    public void SetAudioMaster(Slider slider)
    {
        Debug.Log("called");
        Debug.Log("Audio Value: "+slider.value);
        soundSet.SetVolumeMaster(slider.value);
    }

    public void SetAudioSFX(Slider slider)
    {
        soundSet.SetVolumeSFX(slider.value);
    }

    public void SetAudioMusic(Slider slider)
    {
        soundSet.SetVolumeMusic(slider.value);
    }

    //Player Getter

    public PlayerController GetPlayer()
    {
        return player;
    }
}
