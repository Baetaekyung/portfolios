using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum EventType
{
    Appear,
    Screem,
    ComeToPlayer,
    DummySpawn,
    GirlSuprise,
}

public abstract class GhostEvent : MonoBehaviour
{
    public EventType eventType;

    public abstract void StartEvent();

    public abstract void FinishEvent();
}
