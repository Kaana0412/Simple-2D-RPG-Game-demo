using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected Rigidbody2D rb;
    protected float xinput;
    protected float yinput;
    private string AnimBoolName;
    protected float StateTimer;
    protected bool TriggerCalled;


    public State(Player _player, PlayerStateMachine _stateMachine, string _AnimBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.AnimBoolName = _AnimBoolName; 
    }

    public virtual void Enter()
    {
        player.anim.SetBool(AnimBoolName,true);
        rb = player.rb;
        TriggerCalled = false;
    }

    public virtual void Update()
    {
        StateTimer -= Time.deltaTime;
        xinput = Input.GetAxisRaw("Horizontal");
        yinput = Input.GetAxisRaw("Vertical");
        player.anim.SetFloat("yVelocity", rb.velocity.y);


    }

    public virtual void Exit()
    {

        player.anim.SetBool(AnimBoolName, false);

    }

    public virtual void AnimationFinishTrigger()
    {
        TriggerCalled = true;
    }
}
