public class SlenderManObject : CaptureGhost
{
    public override void Captured()
    {
        base.Captured();
        GhostEventsManager.Instance.DoEvent(EventType.ComeToPlayer);
    }
}
