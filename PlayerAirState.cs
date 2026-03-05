using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : State
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _AnimBoolName) : base(_player, _stateMachine, _AnimBoolName)
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

        if (player.isWallDetected())
            stateMachine.ChangeState(player.wallSlide);

        if (player.isGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
            rb.velocity = new Vector2(0, rb.velocity.y);

        }


        if (xinput != 0)
            player.SetVelocity(xinput * player.MoveSpeed * 0.8f, rb.velocity.y);
    }
}
