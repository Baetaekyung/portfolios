using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMSoundValueChange : MonoBehaviour
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
        if (audioPlayer == null) return;
        if (BgmManager.Instance == null) return;

        BgmManager.Instance.BGMVolume = slider.value;
        audioPlayer.volume = slider.value;
    }
}
