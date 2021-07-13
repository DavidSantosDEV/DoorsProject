using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Musics")]
    [SerializeField]
    private AudioClip songMainMenu;
    [SerializeField]
    private AudioClip songHouse;
    [SerializeField]
    private AudioClip songCombat;

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

    }


}
