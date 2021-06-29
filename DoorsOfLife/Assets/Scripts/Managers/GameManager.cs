using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.Audio;
using UnityEngine;

public enum DoorsAndNumbers : int
{
    HouseDoor = 0,
    GardenDoor = 1
}

public class GameManager : MonoBehaviour
{
    public event Action OnEnemiesPause;
    public event Action GameUnPaused;


    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private bool LockFPS=false;
    [SerializeField][Range(30, 144)]
    private int lockedFPS = 60;

    public SoundBasics soundSet;

    [SerializeField]
    private int textSpeed=40;
    public int TextSpeed => textSpeed;

    [Header("Key related stuff")]
    public bool[] key = new bool[2];

    private bool gamepaused=false;

    public bool GameIsPaused => gamepaused;

    public static GameManager Instance { get; private set; } = null;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
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

    void Start()
    {
        SetAudioPrevious();

        //SetCollisionEnemies();
    }

    private void SetCollisionEnemies()
    {
        Collider2D playerCollider = player.gameObject.GetComponentInParent<Collider2D>();
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("EnemyFeet");
        foreach(GameObject en in Enemies)
        {
            Physics2D.IgnoreCollision(en.GetComponent<Collider2D>(), playerCollider,true);
        }
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
        if(OnEnemiesPause!=null)
        OnEnemiesPause.Invoke();
        
        Cursor.visible = true;
        Time.timeScale = 0;
        //soundSet.
        gamepaused = true;
        UIManager.Instance.ShowPauseCanvas();
        player.EnableMenuControls();
    }

    private void UnPauseGame()
    {
        if (GameUnPaused!=null)
        {
            GameUnPaused.Invoke();
        }
        
        Cursor.visible = false;
        Time.timeScale = 1;
        gamepaused = false;
        UIManager.Instance.HidePauseCanvas();
        if(player)
        player.EnableGameplayControls();
    }

    private void PauseGameNoCanvas()
    {
        OnEnemiesPause.Invoke();
        Time.timeScale = 0;
        gamepaused = true;
    }

    public void StopEnemies()
    {
        OnEnemiesPause.Invoke();
    }

    public void ShowGameOver()
    {
        PauseGameNoCanvas();
        UIManager.Instance.ShowGameOver();
        Debug.Log("Game Over");
        //ChangeToMenu();
    }

    #endregion

    #region Level Changing 


    private IEnumerator LoadScene(int level)
    {
        isOpeningLevel = true;
        UnPauseGame();
        UIManager.Instance.ShowLoadingScreen();

        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(level);
        while (!sceneLoading.isDone)
        {
            Debug.Log("Progress: " + sceneLoading.progress);
            yield return null;
        }
        Debug.Log("Scene Loaded");

        UIManager.Instance.HideLoadingScreen();
        yield return null;

        isOpeningLevel = false;
    }

    bool isOpeningLevel=false;
    public void Openlevel(int level)
    {
        if (isOpeningLevel==false)
        {
            StartCoroutine(LoadScene(level));
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //Menu
            UIManager.Instance.ShowMenuStuff();
            UIManager.Instance.HidePauseCanvas();
            UIManager.Instance.HideGameOver();
            UIManager.Instance.HideGameplayStuff();
        }
        else
        {
            //Game
            UIManager.Instance.HideMenuStuff();
            UIManager.Instance.ShowGameplayStuff();

            if (player == null)
            {
                player = FindObjectOfType<PlayerController>();
                if (!player)
                {
                    player = Instantiate(playerPrefab).GetComponent<PlayerController>();
                }
                DontDestroyOnLoad(player.gameObject.transform.parent);
            }
            
        }
    }

    #endregion

    public void CloseGame()
    {
        Application.Quit();
    }





    //AUDIO STUFF HERE
    #region Audio
    private void SetAudioPrevious()
    {
        soundSet.RestorePreviousValues();
    }

    public void SetAudioMaster(Slider slider)
    {
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
    #endregion
    [SerializeField]
    TMPro.TMP_Dropdown DropBoxResolutions;
    #region Graphics Settings
    private void SettupResDrop()
    {
        Resolution[] resolutions = Screen.resolutions;
        List<string> reso = new List<string>();
        foreach(Resolution res in resolutions)
        {
            reso.Add(res.width +""+ res.height);
        }
        DropBoxResolutions.AddOptions(reso);
    }
    

    #endregion

    //Player Getter

    public PlayerController GetPlayer()
    {
        return player;
    }
}
