using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    public TitleUI titleUI;
    public DialoguePanel dialoguePanel;

    public static bool fullScreen = true;

    public void ResetTitle()
    {
        titleUI.ResetUIPosition();
        PopUpManager.Instance.UnloadAllPopUps();
    }

}
