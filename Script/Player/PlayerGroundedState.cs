using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : State
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _AnimBoolName) : base(_player, _stateMachine, _AnimBoolName)
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
        if(Input.GetKeyDown(KeyCode.Q))
            stateMachine.ChangeState(player.counterAttackState);   

        if (Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.ChangeState(player.attackState);

        if (!player.isGroundDetected())
            stateMachine.ChangeState(player.airState);

        if (Input.GetKeyDown(KeyCode.Space) && player.isGroundDetected())
            stateMachine.ChangeState(player.jumpState);
    }
}
