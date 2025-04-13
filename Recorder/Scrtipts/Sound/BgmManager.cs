using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgmManager : MonoSingleton<BgmManager>
{
    public float BGMVolume = 0.5f;
    public float SFXVolume = 0.5f;

    public AudioSource soundPlayer;
    public AudioClip introBgm;

    protected override void Awake()
    {
        base.Awake();
        soundPlayer.loop = true;
        ChangeBackgroundMusic(introBgm);
    }

    public void ChangeBackgroundMusic(AudioClip clip)
    {
        soundPlayer.Stop();
        soundPlayer.clip = clip;
        soundPlayer.Play();
    }

    public void SleepBGM()
    {
        soundPlayer.Stop();
    }
}
