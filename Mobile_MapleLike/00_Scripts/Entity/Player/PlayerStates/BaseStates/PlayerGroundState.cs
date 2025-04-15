
using UnityEngine;

public abstract class PlayerGroundState : PlayerState, IBasePlayerState
{
    private PlayerMoveController _moveController;

    protected PlayerGroundState(Player player, PlayerStateMachine stateMachine, EPlayerStateEnum state)
        : base(player, stateMachine, state) { }

    public void EnterBaseState()
    {
        _moveController = _player.GetEntityCompo<PlayerMoveController>();

        _moveController.OnJump += ChangeToJumpState;
    }

    public void ExitBaseState()
    {
        _moveController.OnJump -= ChangeToJumpState;
    }

    private void ChangeToJumpState() => _stateMachine.ChangeState(EPlayerStateEnum.JUMP);
}
