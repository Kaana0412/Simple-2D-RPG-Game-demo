using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _AnimBoolName) : base(_player, _stateMachine, _AnimBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(xinput * player.MoveSpeed, rb.velocity.y);

        if (xinput == 0)
            stateMachine.ChangeState(player.idleState);

    }
}
