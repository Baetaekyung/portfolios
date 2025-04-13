using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> OnMovementChanged;
    public event Action<Vector2> OnMouseChanged;
    public event Action<bool> OnRunning;
    public event Action<bool> OnRecord;
    public event Action OnFire;
    public event Action OnUIOpen;

    private bool _isRun = false;
    private bool _isRecording = false;

    private void Update()
    {
        UIOpenInput();

        if (!CursorManager.Instance.uiMode)
        {
            MovementInput();
            MouseChangeInput();
            CaptureInput();
            RunningInput();
            RecordInput();
        }
    }

    private void MovementInput()
    {
        float horizontal_Input = Input.GetAxisRaw("Horizontal");
        float vertical_Input = Input.GetAxisRaw("Vertical");

        Vector2 movementVec = new Vector2(horizontal_Input, vertical_Input);
        movementVec.Normalize();

        OnMovementChanged?.Invoke(movementVec);
    }

    private void CaptureInput()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            CursorManager.Instance.SetCursorVisibleFalse();
            OnFire?.Invoke();
        }
    }

    private void MouseChangeInput()
    {
        float xInput = Input.GetAxisRaw("Mouse X");
        float yInput = Input.GetAxisRaw("Mouse Y");
        Vector2 mouseChangeVec = new Vector2(xInput, yInput);

        OnMouseChanged?.Invoke(mouseChangeVec);
    }    

    private void RunningInput()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isRun = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            _isRun = false;
        }

        OnRunning?.Invoke(_isRun);
    }

    private void RecordInput()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            _isRecording = !_isRecording;
            OnRecord?.Invoke(_isRecording);
        }
    }

    private void UIOpenInput()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            OnUIOpen?.Invoke();
        }
    }
}
