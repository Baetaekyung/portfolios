using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SettingPanel : MonoBehaviour, IPopUpable
{
    [SerializeField] private CanvasGroup _settingPanel;

    private void Start()
    {
       
    }

    public void PopUp()
    {
        _settingPanel.DOFade(1, 0.15f);
        _settingPanel.interactable = true;
    }

    public void PopDown()
    {
        _settingPanel.DOFade(0, 0.15f);
        _settingPanel.interactable = false;
    }
}
