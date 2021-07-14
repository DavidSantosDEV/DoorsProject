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

    [Header("Sources")]
    [SerializeField]
    private AudioSource mainSource;
    [SerializeField]
    private AudioSource extraSourceCombat;
    [SerializeField]
    private AudioSource auxSource;

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
        extraSourceCombat.clip = songCombat;
        extraSourceCombat.volume = 0;
        extraSourceCombat.Play();

        //SceneManager.activeSceneChanged += scene => UpdateMusicLevel();
        DontDestroyOnLoad(gameObject);
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

    }

    public void StopMenuMusic()
    {

    }


}
