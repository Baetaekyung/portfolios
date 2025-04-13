using UnityEngine;
using UnityEngine.UI;

public class SettingPanelUnloadButton : MonoBehaviour
{
    private Button _settingUnloadButton;

    private void Awake()
    {
        _settingUnloadButton = GetComponent<Button>();
    }

    private void Start()
    {
        _settingUnloadButton.onClick.AddListener(HandleUnloadEvent);
    }

    private void HandleUnloadEvent()
    {
        PopUpManager.Instance.UnloadAllPopUps();
    }
}
