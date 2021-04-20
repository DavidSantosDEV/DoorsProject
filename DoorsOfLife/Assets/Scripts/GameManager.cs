using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public SoundBasics soundSet;

    [Header("Key related stuff")]
    public bool[] key;

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

    
    float deltaTime = 0.0f;

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        
    }
    void OnGUI()
    {
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
        ChangeToMenu();
    }


    public void ChangeToLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeToMenu()
    {
        if (Time.timeScale == 0) UnPauseGame();
        SceneManager.LoadScene(0);
    }

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
