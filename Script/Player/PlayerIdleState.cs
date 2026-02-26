using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _AnimBoolName) : base(_player, _stateMachine, _AnimBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        rb.velocity=new Vector2(0,0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (xinput != 0)
            stateMachine.ChangeState(player.moveState);
    }
}
