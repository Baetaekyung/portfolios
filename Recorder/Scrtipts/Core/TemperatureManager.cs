using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class TemperatureManager : MonoSingleton<TemperatureManager>
{
    [SerializeField] private Volume _globalVolume;
    [SerializeField] private VolumeProfile _coldProfile;
    [SerializeField] private VolumeProfile _normalProfile;
    [SerializeField] private float _coldSpeed;
    
    public void OnColdArea()
    {
        PlayerManager.Instance.Player.coldMultiplierValue = _coldSpeed;
        _globalVolume.profile = _coldProfile;
    }

    public void OutColdArea()
    {
        PlayerManager.Instance.Player.coldMultiplierValue = 1f;
        _globalVolume.profile = _normalProfile;
    }
}
