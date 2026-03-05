using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMoveState : MushroomGroundedState
{
    public MushroomMoveState(Enemy _enemyBase, EnemyStateMachmine _stateMachmine, string _animBoolName, Enemy_Mushroom _enemy) : base(_enemyBase, _stateMachmine, _animBoolName, _enemy)
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

        enemy.SetVelocity(enemy.moveSpeed*enemy.FacingDir, rb.velocity.y);

        if(enemy.isWallDetected()|| !enemy.isGroundDetected())
        {
            enemy.Flip();
            stateMachmine.ChangeState(enemy.idleState);
        }
    }
}
