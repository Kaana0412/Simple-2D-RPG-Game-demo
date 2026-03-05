using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : State
{
    private int ComboCounter;
    private float LastTimeAttacked;
    private float ComboWindow = 2f;

    public PlayerAttackState(Player _player, PlayerStateMachine _stateMachine, string _AnimBoolName) : base(_player, _stateMachine, _AnimBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (ComboCounter > 2 || Time.time >= LastTimeAttacked + ComboWindow)
            ComboCounter = 0;

        player.anim.SetInteger("ComboCounter", ComboCounter);

        StateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();

        ComboCounter++;
        LastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        if (StateTimer < 0)
            rb.velocity = new Vector2(0, 0);

        if (TriggerCalled) 
            stateMachine.ChangeState(player.idleState);
    }
}
