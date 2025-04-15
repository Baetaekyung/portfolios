using System;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    private PlayerMoveController _moveController;

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, EPlayerStateEnum state)
        : base(player, stateMachine, state)
    {
        _moveController = player.GetEntityCompo<PlayerMoveController>();
    }

    public override void EnterState()
    {
        base.EnterState();

        _player.GetEntityCompo<PlayerGroundChecker>().OnGroundHit += HandleStateChangeToIdle;
        _moveController.OnJump += HandleStateChangeToJump;

        JumpAction();
    }

    public override void ExitState()
    {
        _player.GetEntityCompo<PlayerGroundChecker>().OnGroundHit -= HandleStateChangeToIdle;
        _moveController.OnJump -= HandleStateChangeToJump;

        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if(_moveController.GetRbComponent.linearVelocityY < 0)
            _stateMachine.ChangeState(EPlayerStateEnum.FALL);
    }

    private void JumpAction()
    {
        if (_moveController.CurrentJumpCount < _moveController.GetJumpData.JumpCount)
        {
            //�� ����
            if (_moveController.CurrentJumpCount == 0
                && InputManager.Inst.Direction == Vector2.up)
            {
                _moveController.CurrentJumpCount = _moveController.GetJumpData.JumpCount; //Jump ���ϰ�

                _moveController.GetRbComponent.AddForce(
                    Vector2.up * _moveController.GetJumpData.UpJumpForce,
                    ForceMode2D.Impulse);

                return;
            }

            //Jump�� 1�ܿ��� 2~3�� �ٷ� ����Ǵ� �� �˰� ��ġ��
            Vector2 jumpActionData = _moveController.GetJumpData.GetJumpDirection(_moveController.CurrentJumpCount);

            Vector2 jumpWithDirection = new Vector2(
                jumpActionData.x * InputManager.Inst.LastInputDirectionOnlyX,
                jumpActionData.y).normalized;

            if (_moveController.CurrentJumpCount > 0) //�ε巴�� ���� �ϱ� ����
                _moveController.StopImmediately();

            _moveController.GetRbComponent.AddForce(
                jumpWithDirection * _moveController.GetJumpData.GetJumpForce(_moveController.CurrentJumpCount),
                ForceMode2D.Impulse);

            _moveController.CurrentJumpCount++;
        }
    }

    private void HandleStateChangeToIdle() => _stateMachine.ChangeState(EPlayerStateEnum.IDLE);

    private void HandleStateChangeToJump() => _stateMachine.ChangeState(EPlayerStateEnum.JUMP);
}
