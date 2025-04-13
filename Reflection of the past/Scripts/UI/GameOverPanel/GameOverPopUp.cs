using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPopUp : MonoBehaviour, IPopUpable
{
    private CanvasGroup _gameOverPanelGroup;
    [SerializeField] private Image backGround;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private DescriptionSO DescriptinSo;
    private void Awake()
    {
        _gameOverPanelGroup = GetComponent<CanvasGroup>();
    }

    public void PopUp()
    {
        backGround.gameObject.SetActive(true);
        gameOverText.SetText(DescriptinSo.GetDescriptionRandom());
        
        backGround.DOFade(0.7f , 0.7f).OnComplete(() =>
        {
            _gameOverPanelGroup.DOFade(1, 0.3f);
        });
    }

    public void PopDown()
    {
        _gameOverPanelGroup.DOFade(0, 0f);
    }
}
