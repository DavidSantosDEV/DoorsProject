using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MusicManager : MonoBehaviour
{
    [Header("Musics")]
    [SerializeField]
    private AudioClip songMainMenu;
    [SerializeField]
    private AudioClip songHouse;
    [SerializeField]
    private AudioClip songGarden;
    [SerializeField]
    private AudioClip songCombat;
    [SerializeField]
    private AudioClip songDeath;
    [SerializeField]
    private AudioClip songVictory;

    [Header("Sounds")]
    [SerializeField]
    private AudioClip textSound;

    [Header("Sources")]
    [SerializeField]
    private AudioSource mainSource;
    [SerializeField]
    private AudioSource extraSourceCombat;
    [SerializeField]
    private AudioSource auxSource;
    [SerializeField]
    private AudioSource textSource;
    [SerializeField]
    private AudioSource blingSource;

    [Header("Time")]
    [SerializeField]
    private float speedChangeMusic=1;

    public static MusicManager Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            CustomSetup();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void CustomSetup() //Add stuff here when needed
    {
        mainSource.loop = true;

        extraSourceCombat.clip = songCombat;
        extraSourceCombat.volume = 0;
        extraSourceCombat.loop = true;
        extraSourceCombat.Play();

        auxSource.loop = false;
        auxSource.playOnAwake = false;

        textSource.playOnAwake = false;
        textSource.loop = false;
        textSource.clip = textSound;
        SceneManager.activeSceneChanged += OnSceneLoaded;
        DontDestroyOnLoad(gameObject);
    }

    private void OnSceneLoaded(Scene scene, Scene newScene)
    {
        ClearCombatMusic();
    }

    public void PlayTextEffect()
    {
        textSource.Play();
    }

    [SerializeField][ShowOnly]
    List<EnemyScript> enemiesActive = new List<EnemyScript>();

    public void AddEnemyAlert(EnemyScript en)
    {
        enemiesActive.Add(en);
        UpdateMusicCombat();
    }

    public void RemoveEnemyAlert(EnemyScript en)
    {
        enemiesActive.Remove(en);
        UpdateMusicCombat();
    }

    public float GetCurrentMainVolume()
    {
        return mainSource.volume;
    }

    public void SetMainVolume(float val)
    {
        mainSource.volume = val;
    }

    public void ClearCombatMusic()
    {
        enemiesActive.Clear();
        extraSourceCombat.volume = 0;
    }

    private bool ActivatingCombat = false;
    public void UpdateMusicCombat()
    {
        if (enemiesActive.Count == 0)
        {
            StopCombatMusic();
        }
        else
        {
            ActivateCombatMusic();
        }
    }

    private void StopCombatMusic()
    {
        ActivatingCombat = false;
        StopCoroutine(IncreaseCombatVol());
        StartCoroutine(DecreaseCombatVol());
    }

    private void ActivateCombatMusic()
    {
        ActivatingCombat = true;
        StopCoroutine(DecreaseCombatVol());
        StartCoroutine(IncreaseCombatVol());
    }

    private IEnumerator IncreaseCombatVol()
    {
        while (extraSourceCombat.volume < 1)
        {
            if (ActivatingCombat)
            {
                float delta = 1 * Time.deltaTime * (speedChangeMusic / 1);
                extraSourceCombat.volume += Mathf.Clamp01(delta);
                mainSource.volume -= Mathf.Clamp01(delta);
                yield return null;
            }

        }
        if (ActivatingCombat)
        {
            mainSource.volume = 0;
            extraSourceCombat.volume = 1;
        }

    }

    private IEnumerator DecreaseCombatVol()
    {
        while (extraSourceCombat.volume > 0)
        {
            if (!ActivatingCombat)
            {
                float delta = 1 * Time.deltaTime * (speedChangeMusic / 1);
                extraSourceCombat.volume -= delta;
                mainSource.volume += delta;
                yield return null;
            }

        }
        if (!ActivatingCombat)
        {
            mainSource.volume = 1;
            extraSourceCombat.volume = 0;
        }
    }

    public void ActivateMenuMusic()
    {
        mainSource.clip = songMainMenu;
        mainSource.Play();
    }

    public void ActivateGardenMusic()
    {
        mainSource.clip = songGarden;
        mainSource.Play();
    }

    public void ActivateHouseMusic()
    {
        mainSource.clip = songHouse;
        mainSource.Play();
    }

    public void UpdateMusicLevel(int level)
    {
        enemiesActive.Clear();
        mainSource.volume = 1;
        extraSourceCombat.volume = 0;
        switch (level)
        {
            case 0:
                ActivateMenuMusic();
                break;
            case 1:
                ActivateHouseMusic();
                break;
            case 2:
                ActivateGardenMusic();
                break;
            default:
                StopMusic();
                break;
        }
    }

    public void StopMusic()
    {
        mainSource.clip = null;
    }


    //sfx

    public void PlayDefeatSound()
    {
        auxSource.clip = songDeath;
        auxSource.Play();
    }

    public void PlayWinSound()
    {
        auxSource.clip = songVictory;
        auxSource.Play();
    }
    

    public void playBling()
    {
        blingSource?.Play();
    }
}
