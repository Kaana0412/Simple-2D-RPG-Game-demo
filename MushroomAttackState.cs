using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAttackState : EnemyState
{
    private Enemy_Mushroom enemy;
    public MushroomAttackState(Enemy _enemyBase, EnemyStateMachmine _stateMachmine, string _animBoolName, Enemy_Mushroom _enemy ) : base(_enemyBase, _stateMachmine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        enemy.lastAttackTime = Time.time;
    }

    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(0,0);

        if (triggerCalled)
            stateMachmine.ChangeState(enemy.battleState);
    }
}
