using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//[MonoSingletonUsage(MonoSingletonFlags.DontDestroyOnLoad)]
public class PopUpManager : MonoSingleton<PopUpManager>
{
    public SettingPanel settingPanel;
    public GameOverPopUp gameOverPopUp;
    public DialoguePanel dialoguePanel;
    private Stack<IPopUpable> _popUpStack = new Stack<IPopUpable>();
    
    protected override void Awake()
    {
        base.Awake();
        
        _popUpStack.Push(settingPanel);
        _popUpStack.Push(gameOverPopUp);
    }

    private void Start()
    {
        UnloadAllPopUps();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _popUpStack.TryPop(out var popUp);
            
            if (popUp != null)
            {
                popUp.PopDown();
            }
            else
            {
                ShowSettingPanel();
            }
        }
    }

    public void ShowSettingPanel()
    {
        settingPanel.PopUp();
        _popUpStack.Push(settingPanel);
    }

    public void ShowGameOverPanel()
    {
        gameOverPopUp.gameObject.SetActive(true);
        
        gameOverPopUp.PopUp();
        _popUpStack.Push(gameOverPopUp);
    }
    
    public void UnloadAllPopUps()
    {
        while (_popUpStack.Count != 0)
        {
            var popUp = _popUpStack.Pop();
            popUp.PopDown();
        }
    }
}
