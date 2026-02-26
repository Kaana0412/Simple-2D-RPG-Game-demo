using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachmine stateMachmine;
    protected Enemy enemyBase;
    protected Rigidbody2D rb;

    protected bool triggerCalled;
    private string animBoolName;

    protected float stateTimer;

    public EnemyState(Enemy _enemyBase, EnemyStateMachmine _stateMachmine, string _animBoolName)
    {
        this.stateMachmine = _stateMachmine;
        this.enemyBase = _enemyBase;
        this.animBoolName = _animBoolName;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        rb = enemyBase.rb;
        enemyBase.anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        enemyBase.anim.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }

}
