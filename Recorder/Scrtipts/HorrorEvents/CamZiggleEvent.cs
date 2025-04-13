using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CamZiggleEvent : MonoBehaviour
{
    private Volume globalVolume;
    private float _contrastValue;

    private void Awake()
    {
        globalVolume = GetComponent<Volume>();
    }

    private void Update()
    {
        if (PlayerManager.Instance.isInGhostArea)
        {
            Ziggle();
            return;
        }


        ZiggleOut();
    }

    private void Ziggle()
    {
        globalVolume.profile.TryGet<ColorAdjustments>(out ColorAdjustments a);
        _contrastValue = Random.Range(-30f, -70f);
        a.contrast.value = _contrastValue;
    }

    private void ZiggleOut()
    {
        globalVolume.profile.TryGet<ColorAdjustments>(out ColorAdjustments a);
        a.contrast.value = Mathf.Lerp(a.contrast.value, 30, Time.deltaTime * 3f);
    }
}
