using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder :  Equipment
{
    public AudioSource NoisePlayer;
    public AudioClip Noise;

    private void OnEnable()
    {
        DefaultClipPlay();
        NoisePlayer.volume = 0.5f;
    }

    private void OnDisable()
    {
        NoisePlayer.clip = null;
        NoisePlayer.loop = false;
        NoisePlayer.Stop();
    }

    private void Update()
    {
        if(PlayerManager.Instance.isInGhostArea)
        {
            NoisePlayer.volume = 1;
        }
        else
        {
            NoisePlayer.volume = 0.5f;
        }
    }

    private void DefaultClipPlay()
    {
        NoisePlayer.clip = Noise;
        NoisePlayer.loop = true;
        NoisePlayer.Play();
    }
}
