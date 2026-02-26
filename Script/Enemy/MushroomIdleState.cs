using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomIdleState : MushroomGroundedState
{
    public MushroomIdleState(Enemy _enemyBase, EnemyStateMachmine _stateMachmine, string _animBoolName, Enemy_Mushroom _enemy) : base(_enemyBase, _stateMachmine, _animBoolName, _enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0f) 
            stateMachmine.ChangeState(enemy.moveState);
    }
}
