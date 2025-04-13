using System.Collections;
using UnityEngine;

public class DummySpawnEvent : GhostEvent
{
    public GameObject dummyParent;
    public GameObject[] dummys;
    public float waitSec = 1f;
    private WaitForSeconds waitFor;

    private void Awake()
    {
        foreach (var dummy in dummys)
        {
            dummy.gameObject.SetActive(false);
        }

        waitFor = new WaitForSeconds(waitSec);
    }

    public override void StartEvent()
    {
        StartCoroutine(EventRoutine());
    }

    private IEnumerator EventRoutine()
    {
        foreach (var dummy in dummys)
        {
            dummy.gameObject.SetActive(true);

            AudioSource dummySound = dummy.GetComponent<AudioSource>();
            dummySound.Play();

            yield return waitFor;
        }

        FinishEvent();
    }

    public override void FinishEvent()
    {

    }
}
