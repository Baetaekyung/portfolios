using System.Collections;
using UnityEngine;

public class ScreemEvent : GhostEvent
{
    private AudioClip _clip;

    public void SetClip(AudioClip settingClip)
    {
        _clip = settingClip;
    }

    public override void StartEvent()
    {
        //StartCoroutine(EventRoutine());
    }

    public override void FinishEvent()
    {

    }

    //private IEnumerator EventRoutine()
    //{
    //    for (int i = 0; i < 3; i++)
    //    {
    //        _clip.Play();
    //        yield return null;
    //    }

    //    FinishEvent();
    //}
}
