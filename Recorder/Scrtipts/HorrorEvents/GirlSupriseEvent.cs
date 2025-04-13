using System.Collections;
using UnityEngine;

public class GirlSupriseEvent : GhostEvent
{
    public GameObject girl;
    [SerializeField] private float _disappearTime;
    private WaitForSeconds _waitSec;

    private void Awake()
    {
        _waitSec = new WaitForSeconds(_disappearTime);
    }

    public override void StartEvent()
    {
        
        StartCoroutine(Routine());
    }

    private IEnumerator Routine()
    {
        int t = 10;
        while(t > 0)
        {
            girl.gameObject.SetActive(true);
            yield return _waitSec;
            FinishEvent();
            t--;
        }
    }

    public override void FinishEvent()
    {
        girl.gameObject.SetActive(false);
    }
}
