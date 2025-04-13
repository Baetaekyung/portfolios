using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearEvent : GhostEvent
{
    public GameObject appearParticle;
    public AudioClip appearSound;
    public float remainTime = 1.5f;
    private GameObject _appearObject;

    public void SetAppearObject(GameObject settingObj)
    {
        _appearObject = Instantiate(settingObj, Vector3.zero, Quaternion.identity);
    }

    public override void StartEvent()
    {
        if (_appearObject == null) Debug.LogWarning("SetAppearObject로 나타날 오브젝트를 설정해주십시오");

        StartCoroutine(AppearRoutine());
    }
    public override void FinishEvent()
    {
        _appearObject.gameObject.SetActive(false);
    }

    private IEnumerator AppearRoutine()
    {
        _appearObject.gameObject.SetActive(true);
        _appearObject.transform.position =
            PlayerManager.Instance.Player.transform.position + 
            PlayerManager.Instance.Player.transform.forward * 2;
        _appearObject.transform.LookAt(PlayerManager.Instance.Player.transform.position);

        //Instantiate(appearParticle, ghost.transform.position, Quaternion.identity);
        //appearSound.Play();

        yield return new WaitForSeconds(remainTime);

        FinishEvent();
    }
}
