using DG.Tweening;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField]
    [ColorUsage(true, true)] private Color _pointedColor;
    [SerializeField] private Material _mat;
    [SerializeField] private GameObject _light;

    [SerializeField] private CanvasGroup _clearUI;
    [SerializeField] private CanvasGroup _failUI;

    [SerializeField] private GameObject _camFrame;

    private void Start()
    {
        _clearUI.gameObject.SetActive(false);
        _failUI.gameObject.SetActive(false);
        _light.SetActive(false);
    }

    private void Update()
    {
        BoatUpdate();
    }

    public void GameClear()
    {
        CursorManager.Instance.SetCursorVisibleTrue();
        CursorManager.Instance.uiMode = true;
        GhostAggressiveManager.Instance.StopAdd();

        if (GameManager.Instance.findGhost)
        {
            SaveManager.Instance.SetClearData(GhostManager.Instance.selectedGhost.data.ghostName);
            SaveManager.Instance.SetTimeData(GhostManager.Instance.selectedGhost.data.ghostName,
                GameManager.Instance.timer);

            _camFrame.SetActive(false);
            _clearUI.gameObject.SetActive(true);
            _clearUI.DOFade(1, 1.5f);
        }
        else
        {
            _camFrame.SetActive(false);
            _failUI.gameObject.SetActive(true);
            _failUI.DOFade(1, 1.5f);
        }
    }

    private void BoatUpdate()
    {
        if (GameManager.Instance.findGhost)
        {
            _light.SetActive(true);
            GetPointed();
        }
        else
        {
            OutPointed();
            _light.SetActive(false);
        }
    }

    public void GetPointed()
    {
        _mat.color = _pointedColor;
    }

    public void OutPointed()
    {
        _mat.color = Color.white;
    }
}
