using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSetting : MonoBehaviour
{
    public AudioSource[] bgmSource;
    public AudioSource[] sfxSource;

    private void Start()
    {
        Setting();
    }

    private void Setting()
    {
        foreach (var bgm in bgmSource)
        {
            bgm.volume = BgmManager.Instance.BGMVolume;
        }
        foreach (var sfx in sfxSource)
        {
            sfx.volume = BgmManager.Instance.SFXVolume;
        }
    }
}
