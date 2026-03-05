using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBattleState : EnemyState
{
    private Transform player;
    private Enemy_Mushroom enemy;
    private int moveDir;
    public MushroomBattleState(Enemy _enemyBase, EnemyStateMachmine _stateMachmine, string _animBoolName, Enemy_Mushroom _enemy) : base(_enemyBase, _stateMachmine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {

        base.Update();
        if ( enemy.IsPlayerDetcted())
        {
            stateTimer = enemy.battleTime;
            
        if (enemy.IsPlayerDetcted().distance < enemy.attackDistance)
        {

            if (CanAttack())
            stateMachmine.ChangeState(enemy.attackState);

        }
        }
        else
        {
            if (stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position)>15)
                stateMachmine.ChangeState(enemy.idleState);
        }

        if (player.position.x > enemy.transform.position.x)
            moveDir = 1;
        else
            moveDir = -1;

        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
    }

    private bool CanAttack()
    {
        if (Time.time >= enemy.lastAttackTime + enemy.attackCoolDown)
        {
            enemy.lastAttackTime = Time.time;
        return true;

        }
    return false;
    }

}
