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
    public PuzzleChessMaster puzzlechess;

    public void ResetPieces() //DELETE AFTER
    {
        puzzlechess.ResetPuzzle();
    }

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
    }

    void Start()
    {
        SetAudioPrevious();
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
        UIManager.Instance.GameOverScreen();
        Debug.Log("Game Over");
        //ChangeToMenu();
    }

    #endregion

    #region Level Changing 
    public void ChangeToLevel()
    {
        if(Time.timeScale==0) UnPauseGame();
        SceneManager.LoadScene(1);
    }

    public void ChangeToMenu()
    {
        if (Time.timeScale == 0) UnPauseGame();
        SceneManager.LoadScene(0);
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
