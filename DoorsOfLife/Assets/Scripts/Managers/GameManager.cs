using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.Audio;
using UnityEngine;

//Unity has consistently proved that its one of the worst engines to work with, no wonder UE4 is the golden boy
//New input system is a buggy mess! Cant change scenes without it breaking something
public enum DoorsAndNumbers : int
{
    HouseDoor = 0,
    GardenDoor = 1
}

public class GameManager : MonoBehaviour
{
    public event Action OnEnemiesPause;
    public event Action GameUnPaused;

    //[SerializeField]
    //private int maxHealthPlayer=5;

    public void UpdatePlayerHealth(float val)
    {
        currentHealth = val;
    }

    private float currentHealth;


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

    public bool playerCanAttack=false;

    public bool GameIsPaused => gamepaused;

    private PlayerCheckPoint currenCheckPoint = null;

    public void SetCheckPoint(PlayerCheckPoint newCheck)
    {
        currenCheckPoint = newCheck;
    }

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
        MusicManager.Instance.ActivateMenuMusic();
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
        if(OnEnemiesPause != null)
        {
            OnEnemiesPause.Invoke();
        }
        Time.timeScale = 0;
        gamepaused = true;
    }


    public void ShowGameOver()
    {
        UIManager.Instance.ShowGameOver();
    }

    #endregion

    #region Level Changing 

    int previousScene = 0;

    public int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    private IEnumerator LoadScene(int level)
    {
        previousScene = GetCurrentScene();
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
        //if (level == 0) Destroy(player.gameObject.transform.parent);
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
        UIManager.Instance.FindNewEventSystem();
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //Menu
            if (player) //Doesnt fucking work cause unity is retarded
            {
                currentHealth = player.PlayerHeartsComponent.MaxHealth;
                Destroy(player.gameObject.transform.parent.gameObject);
            }
            if (previousScene != 0)
            {
                
                UIManager.Instance.ShowMenuStuff();
                UIManager.Instance.HidePauseCanvas();
                UIManager.Instance.HideGameOver();
                UIManager.Instance.HideGameplayStuff();

                UIManager.Instance.SettupMenu();
                //MusicManager.Instance.ActivateMenuMusic();
            }      
        }
        else
        {
            currentEnemies.Clear();

            //Game
            UIManager.Instance.SettupGameplay();
            UIManager.Instance.HideMenuStuff();
            UIManager.Instance.ShowGameplayStuff();

            if (player == null)
            {
                player = FindObjectOfType<PlayerController>();
                if (!player)
                {
                    GameObject p = Instantiate(playerPrefab);
                    player = p.GetComponentInChildren<PlayerController>(); //its supposed to be in child
                }

                
                //DontDestroyOnLoad(player.gameObject.transform.parent);
            }
            if (currentHealth <= 0)
            {
                currentHealth = player.PlayerHeartsComponent.MaxHealth;
            }
            player.PlayerHeartsComponent.SetHealth(currentHealth);
            player.canAttack = playerCanAttack;

            //player.transform.parent.gameObject.SetActive(false);
            //player.transform.parent.gameObject.SetActive(true);

        }

        MusicManager.Instance?.UpdateMusicLevel(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion

    private List<EnemyScript> currentEnemies= new List<EnemyScript>();

    public void AddEnemy(EnemyScript NewEnemy)
    {
        currentEnemies.Add(NewEnemy);
    }

    private void ClearCurrentEnemies()
    {
        List<EnemyScript> toDelete = new List<EnemyScript>();
        foreach(EnemyScript e in currentEnemies)
        {
            if (e)
            {
                e.ResetSelf();
            }
            else
            {
                toDelete.Add(e);
            }
        }
        foreach(EnemyScript e in toDelete) //Cleaning in case of deaths
        {
            currentEnemies.Remove(e);
        }
    }

    public void ReloadScene()
    {
        //Openlevel(GetCurrentScene());
        if (currenCheckPoint)
        {
            player.transform.parent.position = currenCheckPoint.GetSpawnPoint();
        }
        else
        {
            player.transform.parent.position = GameObject.FindGameObjectWithTag("StartingPoint").transform.position;
        }
        player.Revive();

        ClearCurrentEnemies();
    }


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
