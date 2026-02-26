using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomStunState : EnemyState
{
    private Enemy_Mushroom enemy;
    public MushroomStunState(Enemy _enemyBase, EnemyStateMachmine _stateMachmine, string _animBoolName, Enemy_Mushroom _enemy) : base(_enemyBase, _stateMachmine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.fx.InvokeRepeating("RedColorBlink", 0, .1f);

        stateTimer = enemy.stunDuration;
        rb.velocity = new Vector2(-enemy.FacingDir * enemy.stunDirection.x, enemy.stunDirection.y);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.fx.Invoke("CancelRedBlink",0);
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer <0)
        {
            stateMachmine.ChangeState(enemy.idleState);
        }
    }
}
