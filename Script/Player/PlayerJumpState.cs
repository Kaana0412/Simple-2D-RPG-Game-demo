using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : State
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _AnimBoolName) : base(_player, _stateMachine, _AnimBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        rb.velocity = new Vector2(rb.velocity.x, player.JumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (rb.velocity.y < 0)
            stateMachine.ChangeState(player.airState);
    }
}
