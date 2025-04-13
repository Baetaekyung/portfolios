using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    void Start()
    {
        BgmManager.Instance.ChangeBackgroundMusic(clip);   
    }
}
