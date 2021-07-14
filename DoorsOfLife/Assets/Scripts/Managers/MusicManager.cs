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

    [Header("Sources")]
    [SerializeField]
    private AudioSource mainSource;
    [SerializeField]
    private AudioSource extraSourceCombat;

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
        //SceneManager.activeSceneChanged += scene => UpdateMusicLevel();
        DontDestroyOnLoad(gameObject);
    }

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

    }

    private void ActivateCombatMusic()
    {

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
