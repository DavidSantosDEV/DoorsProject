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
    public bool LockFPS=false;
    [Range(30, 144)]
    public int lockedFPS = 60;

    public SoundBasics soundSet;

    [Header("Key related stuff")]
    public bool[] key = new bool[2];

    public static GameManager Instance { get; private set; } = null;

    // Start is called before the first frame update
    private void Awake()
    {
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

    private void PauseGame()
    {
        Time.timeScale = 0;
        UIManager.Instance.ShowPauseCanvas();
        PlayerController.Instance.EnableMenuControls();
    }

    private void UnPauseGame()
    {
        Time.timeScale = 1;
        UIManager.Instance.HidePauseCanvas();
        PlayerController.Instance.EnableGameplayControls();
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0;
        UIManager.Instance.GameOverScreen();
        Debug.Log("Game Over");
        //ChangeToMenu();
    }

    #endregion

    #region Level Changing 

    private IEnumerator UnloadPreviousScene()
    {
        /*AsyncOperation sceneUnload = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        while (!sceneUnload.isDone)
        {
            Debug.Log(sceneUnload.progress);
            yield return null;
        }
        Debug.Log(sceneUnload.progress);
        yield return null;*/
        SceneManager.UnloadScene(SceneManager.GetActiveScene());
        yield return null;
        StartCoroutine(LoadLevel(1));
    }

    public void ChangeToLevel()
    {
        //GameManager.
        if(Time.timeScale==0) UnPauseGame();

        StartCoroutine(UnloadPreviousScene());
        //SceneManager.LoadScene(1);
        //StartCoroutine(LoadLevel(1));
        //LoadScene(1);
    }

    public void ChangeToMenu()
    {
        if (Time.timeScale == 0) UnPauseGame();
        LoadScene(0);
        //StartCoroutine(LoadLevel(0));
    }

    private void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private IEnumerator LoadLevel(int level)
    {
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(level);
        while (!sceneLoading.isDone)
        {
            Debug.Log("Progress: " + sceneLoading.progress);
            yield return null;
        }
        Debug.Log("Scene Loaded");
        yield return null;
    }

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
}
