using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : CaptureGhost
{
    public override void Captured()
    {
        base.Captured();
        GhostEventsManager.Instance.DoEvent(EventType.GirlSuprise);
    }
}
