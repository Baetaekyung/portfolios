using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadbody : CaptureObject
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void Captured()
    {
        base.Captured();
        GhostEventsManager.Instance.DoEvent(EventType.DummySpawn);
    }
}
