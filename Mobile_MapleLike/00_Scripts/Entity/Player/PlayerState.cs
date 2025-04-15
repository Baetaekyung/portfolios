using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PlayerState
{
    protected event Action OnBaseStateUpdate;

    protected Player             _player;
    protected PlayerStateMachine _stateMachine;
    protected EPlayerStateEnum   _state;

    public EPlayerStateEnum GetStateEnum => _state;

    public PlayerState(Player player, PlayerStateMachine stateMachine, EPlayerStateEnum state)
    {
        _player       = player;
        _stateMachine = stateMachine;
        _state        = state;
    }

    public virtual void EnterState() 
    {
        _player.GetEntityCompo<PlayerVisual>().SetAnimation(_state);

        #region �� Ŭ������ BaseState�� ��ӹ��� Ŭ���� ���� Ȯ��
        bool hasBaseState = typeof(IBasePlayerState).IsAssignableFrom(GetType());
        if(hasBaseState)
        {
            (this as IBasePlayerState).EnterBaseState();
            OnBaseStateUpdate += (this as IBasePlayerState).UpdateBaseState;
        }
        #endregion
    }

    public virtual void UpdateState() 
    {
        OnBaseStateUpdate?.Invoke();
    }

    public virtual void ExitState()
    {
        #region Base ��� Ȯ��
        bool hasBaseState = typeof(IBasePlayerState).IsAssignableFrom(GetType());
        if (hasBaseState)
        {
            (this as IBasePlayerState).ExitBaseState();
            OnBaseStateUpdate -= (this as IBasePlayerState).UpdateBaseState;
        }
        #endregion
    }

    public virtual void FixedUpdateState() { }
}
