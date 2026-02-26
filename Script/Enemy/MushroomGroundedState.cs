using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomGroundedState : EnemyState
{
    protected Enemy_Mushroom enemy;
    protected Transform player;
    public MushroomGroundedState(Enemy _enemyBase, EnemyStateMachmine _stateMachmine, string _animBoolName, Enemy_Mushroom _enemy) : base(_enemyBase, _stateMachmine, _animBoolName)
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

        if (enemy.IsPlayerDetcted() || Vector2.Distance(enemy.transform.position, player.transform.position)<2)
        {
            stateMachmine.ChangeState(enemy.battleState);
        }
    }
}
