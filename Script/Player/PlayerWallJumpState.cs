using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : State
{
    public PlayerWallJumpState(Player _player, PlayerStateMachine _stateMachine, string _AnimBoolName) : base(_player, _stateMachine, _AnimBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StateTimer = 1f;
        rb.velocity = new Vector2(5 * -player.FacingDir, player.JumpForce);
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void Update()
    {
        base.Update();
        if (StateTimer < 0)
            stateMachine.ChangeState(player.airState);

        if (player.isGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
