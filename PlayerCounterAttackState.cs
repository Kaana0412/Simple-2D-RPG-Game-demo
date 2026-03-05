using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounterAttackState : State
{
    public PlayerCounterAttackState(Player _player, PlayerStateMachine _stateMachine, string _AnimBoolName) : base(_player, _stateMachine, _AnimBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StateTimer = player.counterAttackDuration;
        player.anim.SetBool("SuccessfulCounterAttack", false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        
        rb.velocity = new Vector2 (0,0);    

        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                if (hit.GetComponent<Enemy>().CanBeStunned())
                {
                    StateTimer = 10;
                    player.anim.SetBool("SuccessfulCounterAttack", true);
                }
            }
        }

        if (StateTimer < 0 || TriggerCalled)
            stateMachine.ChangeState(player.idleState);
    }
}
