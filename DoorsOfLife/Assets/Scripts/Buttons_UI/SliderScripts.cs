using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderScripts : MonoBehaviour
{
    private Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateMasterSlider()
    {
        GameManager.Instance?.SetAudioMaster(slider);
    }

    public void UpdateSFXSlider()
    {
        GameManager.Instance?.SetAudioSFX(slider);
    }

    public void UpdateMusicSlider()
    {
        GameManager.Instance?.SetAudioMusic(slider);
    }
}
