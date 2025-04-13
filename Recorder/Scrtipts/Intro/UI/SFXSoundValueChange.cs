using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSoundValueChange : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioPlayer;

    private void Awake()
    {
        slider.value = 0.5f;
        SoundValueChanges();
    }

    public void SoundValueChanges()
    {
        BgmManager.Instance.SFXVolume = slider.value;
        audioPlayer.volume = slider.value;
    }
}
