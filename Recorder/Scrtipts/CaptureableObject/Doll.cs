using UnityEngine;

public class Doll : CaptureObject
{
    public GameObject dollEventGhost;
    public AudioClip clip;
    public AudioSource _source;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Captured()
    {
        CapturedSoundEvent();
        GhostEventsManager.Instance.appearEvent.SetAppearObject
            (GhostManager.Instance.selectedGhost.data.ghostDummy);
        GhostEventsManager.Instance.DoEvent(EventType.Appear);
        base.Captured();
    }

    private void CapturedSoundEvent()
    {
        _source.clip = clip;
        _source.Play();
    }
}
