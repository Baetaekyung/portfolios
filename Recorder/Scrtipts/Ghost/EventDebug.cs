using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDebug : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            GhostEventsManager.Instance.DoEvent(EventType.Appear);
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            GhostEventsManager.Instance.DoEvent(EventType.ComeToPlayer);
        }
    }
}
