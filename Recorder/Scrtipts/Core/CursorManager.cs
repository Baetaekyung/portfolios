using UnityEngine;

public class CursorManager : MonoSingleton<CursorManager>
{
    public bool uiMode = false;

    protected override void Awake()
    {
        base.Awake();
        SetCursorVisibleFalse();
    }

    private void Start()
    {
        uiMode = false;
    }

    public void SetCursorVisibleFalse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SetCursorVisibleTrue()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
