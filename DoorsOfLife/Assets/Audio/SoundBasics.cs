using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;



[CreateAssetMenu(fileName = "AudioSettingsGameManager", menuName = "AudioSystem/AudioBasics")]
public class SoundBasics : ScriptableObject 
{

    const string AUDIOMASTER_KEY = "MasterVolume";
    const string AUDIOMUSIC_KEY = "MusicVolume";
    const string AUDIOSFX_KEY = "SFXVolume";
    const string AUDIODIALOGUE_KEY = "DialogueVolume";

    #region Variables
    [SerializeField]
    AudioMixer mixer;
    [SerializeField]
    string audioMaster;
    [SerializeField]
    string audioMusic;
    [SerializeField]
    string audioSFX;
    [SerializeField]
    string audioDialogue;
    #endregion

    public void RestorePreviousValues()
    {
        mixer.SetFloat(audioMaster, PlayerPrefs.GetFloat(AUDIOMASTER_KEY));
        mixer.SetFloat(audioMusic, PlayerPrefs.GetFloat(AUDIOMUSIC_KEY));
        mixer.SetFloat(audioSFX, PlayerPrefs.GetFloat(AUDIOSFX_KEY));
        mixer.SetFloat(audioDialogue, PlayerPrefs.GetFloat(AUDIODIALOGUE_KEY));
        UIManager.Instance.SetValuesAllVolume(PlayerPrefs.GetFloat(AUDIOMASTER_KEY), PlayerPrefs.GetFloat(AUDIOSFX_KEY), PlayerPrefs.GetFloat(AUDIOMUSIC_KEY), PlayerPrefs.GetFloat(AUDIODIALOGUE_KEY));
    }

    private float GetCalculatedAudioValue(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1);//Remember the audio slider needs to have a min value of 0.0001
        return Mathf.Log10(value) * 20;
    }

    public void SetVolumeMaster(float volume)
    {
        volume = GetCalculatedAudioValue(volume);
        mixer.SetFloat(audioMaster, volume);
        SaveVolume(AUDIOMASTER_KEY, volume);
    }

    public void SetVolumeSFX(float volume)
    {
        volume = GetCalculatedAudioValue(volume);
        mixer.SetFloat(audioSFX, volume);
        SaveVolume(AUDIOSFX_KEY, volume);
    }

    public void SetVolumeDialogue(float volume)
    {
        volume = GetCalculatedAudioValue(volume);
        mixer.SetFloat(audioDialogue, volume);
        SaveVolume(AUDIODIALOGUE_KEY, volume);
    }
    public void SetVolumeMusic(float volume)
    {
        volume = GetCalculatedAudioValue(volume);
        mixer.SetFloat(audioMusic, volume);
        SaveVolume(AUDIOMUSIC_KEY, volume);
    }
    
    private void SaveVolume(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }
}
