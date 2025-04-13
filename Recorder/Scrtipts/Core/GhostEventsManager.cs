using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEventsManager : MonoSingleton<GhostEventsManager>
{
    public AppearEvent appearEvent;
    public ScreemEvent screemEvent;
    public GhostComeToPlayerEvent comeEvent;
    public DummySpawnEvent dummySpawnEvent;
    public GirlSupriseEvent girlSupriseEvent;

    private Dictionary<EventType, GhostEvent> eventsDictionary;

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    private void Init()
    {
        eventsDictionary = new Dictionary<EventType, GhostEvent>
        {
            { EventType.Appear, appearEvent },
            { EventType.Screem, screemEvent },
            { EventType.ComeToPlayer, comeEvent},
            { EventType.DummySpawn, dummySpawnEvent},
            { EventType.GirlSuprise, girlSupriseEvent}
        };
    }

    public void DoEvent(EventType eventType)
    {
        eventsDictionary[eventType].StartEvent();
    }
}
