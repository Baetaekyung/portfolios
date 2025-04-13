using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightSlider : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.onValueChanged.AddListener(HandleValueChanged);
    }

    private void HandleValueChanged(float value)
    {
        Screen.brightness = value;
    }
}
