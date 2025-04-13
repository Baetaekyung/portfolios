using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : HoverButton
{
    private Button _settingButton;

    private void Awake()
    {
        _settingButton = GetComponent<Button>();
    }

    private void Start()
    {
        _settingButton.onClick.AddListener(HandleSettingOnEvent);
    }

    private void HandleSettingOnEvent()
    {
        PopUpManager.Instance.ShowSettingPanel();
    }
}
