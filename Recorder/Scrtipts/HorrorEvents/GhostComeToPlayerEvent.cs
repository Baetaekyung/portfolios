using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostComeToPlayerEvent : GhostEvent
{
    public AudioClip followSoundClip;
    public Transform startPos;
    public GameObject runningGhost;
    private bool eventStart = false;

    private void Update()
    {
        if(eventStart)
        {
            runningGhost.transform.position = Vector3.Lerp(runningGhost.transform.position,
                PlayerManager.Instance.Player.transform.position, Time.deltaTime * 4f);

            runningGhost.transform.LookAt(PlayerManager.Instance.Player.transform);
            if(Vector3.Distance(runningGhost.transform.position,
                PlayerManager.Instance.Player.transform.position) <= 1.5f)
            {
                FinishEvent();
            }
        }
    }

    public override void StartEvent()
    {
        runningGhost.SetActive(true);
        runningGhost.transform.position = startPos.position;
        AudioSource aS = runningGhost.GetComponent<AudioSource>();
        aS.Play();
        PlayerManager.Instance.PlayerEar.Stop();
        PlayerManager.Instance.PlayerEar.clip = followSoundClip;
        PlayerManager.Instance.PlayerEar.Play();
        eventStart = true;
    }

    public override void FinishEvent()
    {
        eventStart = false;
        runningGhost.SetActive(false);
    }
}
