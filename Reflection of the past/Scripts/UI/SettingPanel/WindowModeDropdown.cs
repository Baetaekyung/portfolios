using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindowModeDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;

    private void Start()
    {
        _dropdown.onValueChanged.AddListener(HandleWindowModeChanged);
    }

    private void HandleWindowModeChanged(int optionIdx)
    {
        switch (optionIdx)
        {
            case 1:
                UIManager.fullScreen = true;
                Screen.SetResolution(Screen.width, Screen.height, UIManager.fullScreen);
                break;
            case 2:
                UIManager.fullScreen = false;
                Screen.SetResolution(Screen.width, Screen.height, UIManager.fullScreen);
                break;
            default:
                break;
        }
    }
}
