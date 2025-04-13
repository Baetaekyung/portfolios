using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToIntroScreen : MonoBehaviour
{
    public void GoToIntroScene()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
