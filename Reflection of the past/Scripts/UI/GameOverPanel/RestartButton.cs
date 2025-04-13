using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : HoverButton
{
    private Button _titleButton;

    private void Awake()
    {
        _titleButton = GetComponent<Button>();
    }

    private void Start()
    {
        _titleButton.onClick.AddListener(HandleResetTitleEvent);
    }
    
    private void HandleResetTitleEvent()
    {
        UIManager.Instance.ResetTitle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
