using UnityEngine;

public class Paint : CaptureObject
{
    [SerializeField] private GameObject horrorText;
    [SerializeField] private AudioSource _audioSource;

    public override void Captured()
    {
        base.Captured();
        _audioSource.Play();
        horrorText.SetActive(true);
    }
}
