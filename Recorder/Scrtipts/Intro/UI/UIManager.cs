using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public int bgmVolume;
    public int soundEffectVolume;

    public CanvasGroup currentPanel;
    private bool panelOn = false;

    protected override void Awake()
    {
        base.Awake();
        Screen.SetResolution(1920, 1080, true);
    }

    private void Update()
    {
        PanelOff();
    }

    public void PanelOn(CanvasGroup panel)
    {
        if (panelOn) return;

        panelOn = true;
        panel.gameObject.SetActive(true);
        currentPanel = panel;

        panel.DOFade(1, 0.3f);
    }

    public void PanelOn(CanvasGroup panel, float spentTime)
    {
        panel.gameObject.SetActive(true);

        panel.DOFade(1, spentTime);
    }

    public void PanelOff()
    {
        if (panelOn == false || currentPanel == null) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Sequence seq = DOTween.Sequence();

            seq.Append(currentPanel.DOFade(0, 0.3f)).OnComplete(() =>
            {
                panelOn = false;
                currentPanel.gameObject.SetActive(false);
            });
        }
    }

    public void PanelOff(CanvasGroup group, float spentTime)
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(group.DOFade(0, spentTime)).OnComplete(() =>
        {
            group.gameObject.SetActive(false);
        });
    }

    public void PanelOffByButton()
    {
        if (panelOn == false || currentPanel == null) return;

        Sequence seq = DOTween.Sequence();

        seq.Append(currentPanel.DOFade(0, 0.3f)).OnComplete(() =>
        {
            panelOn = false;
            currentPanel.gameObject.SetActive(false);
        });
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }
}
