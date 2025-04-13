using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : HoverButton
{
    private Button _exitButton;

    private void Awake()
    {
        _exitButton = GetComponent<Button>();
    }

    private void Start()
    {
        _exitButton.onClick.AddListener(HandleExitEvent);
    }

    private void HandleExitEvent()
    {
        Application.Quit();
    }
}
