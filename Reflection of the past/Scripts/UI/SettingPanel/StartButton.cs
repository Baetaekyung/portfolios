using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : HoverButton
{
    private Button _startButton;

    private void Awake()
    {
        _startButton = GetComponent<Button>();
    }

    private void Start()
    {
        _startButton.onClick.AddListener(HandleStartEvent);
    }

    private void HandleStartEvent()
    {
        UIManager.Instance.titleUI.GameStartButtonClicked();
    }
}
