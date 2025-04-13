using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenSizeDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;

    private void Start()
    {
        _dropdown.onValueChanged.AddListener(HandleScreenSizeChanged);
    }

    private void HandleScreenSizeChanged(int optionIdx)
    {
        switch (optionIdx)
        {
            case 1:
                Screen.SetResolution(1366, 768, UIManager.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1920, 1080, UIManager.fullScreen);
                break;
            case 3:
                Screen.SetResolution(2560, 1440, UIManager.fullScreen);
                break;
            default:
                break;
        }
    }
}
