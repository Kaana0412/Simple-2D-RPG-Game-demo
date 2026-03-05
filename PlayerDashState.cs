using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : State
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _AnimBoolName) : base(_player, _stateMachine, _AnimBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        StateTimer = player.DashDuration;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0 , rb.velocity.y);

    }

    public override void Update()
    {
        base.Update();

        if (!player.isGroundDetected() && player.isWallDetected()) 
            stateMachine.ChangeState(player.wallSlide);

        player.SetVelocity(player.DashSpeed * player.DashDir, 0);

        if (StateTimer < 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
