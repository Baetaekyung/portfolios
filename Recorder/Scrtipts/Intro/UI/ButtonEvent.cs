using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    public AudioSource soundPlayer;
    public CanvasGroup btnPanel;
    private UIManager _uiManager;

    private void Awake()
    {
        _uiManager = UIManager.Instance;
    }

    public void StartButtonClick(AudioClip clickSound)
    {
        ButtonClick(clickSound);
        StartCoroutine(WaitToStart());
    }

    public void ButtonClick(AudioClip clickSound)
    {
        _uiManager.PanelOn(btnPanel);

        soundPlayer.Stop();
        soundPlayer.clip = clickSound;
        soundPlayer.Play();
    }

    private IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
