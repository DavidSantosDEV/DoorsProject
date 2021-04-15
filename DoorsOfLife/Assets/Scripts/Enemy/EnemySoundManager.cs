using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class EnemySoundManager : MonoBehaviour
{
    private AudioSource myAudio=null;
    [SerializeField]
    private AudioClip attackSource, idleSource, footstepSource, hitSource, deathSource;

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.playOnAwake = false;
    }

    private void ChangeClip(AudioClip clip, bool loop) //Im just doing this ahead for readability sake, so why not
    {
        myAudio.clip = clip;
        myAudio.loop = loop;
    }



    public void PlayAttackSound()
    {
        ChangeClip(attackSource,false);
        myAudio.Play();
    }

    public void StartIdleSound()
    {
        ChangeClip(idleSource,true);
        myAudio.Play();
    }

    public void PlayStepSound()
    {
        ChangeClip(footstepSource, false);
        myAudio.Play();
    }

    public void PlayHitSound()
    {
        ChangeClip(hitSource, false);
        myAudio.Play();
    }

    public void PlayDeathSound()
    {
        ChangeClip(deathSource, false);
        myAudio.Play();
    }
}
