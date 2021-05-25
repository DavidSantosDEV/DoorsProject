using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class StartCutsceneTrigger : MonoBehaviour
{
    [SerializeField]
    VideoPlayer targetVideoPlayer;
    [SerializeField]
    VideoClip videoCutscene;

    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnEnable()
    {
        targetVideoPlayer.loopPointReached += OnCutsceneEnd;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        targetVideoPlayer.enabled = true;
        targetVideoPlayer.clip = videoCutscene;
        targetVideoPlayer.Play();
        
    }

    private void OnCutsceneEnd(VideoPlayer player)
    {
        targetVideoPlayer.enabled = false;
        Destroy(gameObject);
    }


}
