using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mushroom : Enemy
{
    public MushroomIdleState idleState {  get; private set; }
    public MushroomMoveState moveState {  get; private set; }
    public MushroomBattleState battleState { get; private set; }
    public MushroomAttackState attackState { get; private set; }
    public MushroomStunState stunState { get; private set; }
    protected override void Awake()
    {
        base.Awake();

        idleState = new MushroomIdleState(this, StateMachmine, "Idle", this);
        moveState = new MushroomMoveState(this, StateMachmine, "Move", this);
        battleState = new MushroomBattleState(this, StateMachmine, "Move", this);
        attackState = new MushroomAttackState(this, StateMachmine, "Attack", this);
        stunState = new MushroomStunState(this, StateMachmine, "Stun", this);
    }

    protected override void Start()
    {
        base.Start();
        StateMachmine.Initialize(idleState);  
    }

    protected override void Update()
    {
        base.Update();
    }

    public override bool CanBeStunned()
    {
        if (base.CanBeStunned())
        {
            StateMachmine.ChangeState(stunState);
            return true;
        }
        return false;
    }
}
