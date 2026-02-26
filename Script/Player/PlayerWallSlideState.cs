using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : State
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _AnimBoolName) : base(_player, _stateMachine, _AnimBoolName)
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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.wallJump);
            return;
        }

        if (xinput != 0 && xinput != player.FacingDir)
            stateMachine.ChangeState(player.idleState);

        if (yinput <0)
            rb.velocity = new Vector2 (0, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y * 0.7f);

        if (player.isGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }


}
