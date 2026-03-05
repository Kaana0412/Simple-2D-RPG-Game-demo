using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : Entity
{
    [Header ("Attack info")]
    public float counterAttackDuration = .2f;

    [Header("Move info")]
    public float MoveSpeed;
    public float JumpForce;

    [Header("Dash info")]
    [SerializeField] private float DashCooldown;
    private float DashUseageTimer;
    public float DashDir { get; private set; }
    public float DashSpeed;
    public float DashDuration;






    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerJumpState jumpState { get; private set; } 
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlide {  get; private set; }
    public PlayerWallJumpState wallJump { get; private set; }


    public PlayerAttackState attackState { get; private set; }
    public PlayerCounterAttackState counterAttackState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine , "Idle" );
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlide = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJump = new PlayerWallJumpState(this, stateMachine, "Jump");
        attackState = new PlayerAttackState(this, stateMachine, "Attack");
        counterAttackState = new PlayerCounterAttackState(this, stateMachine, "CounterAttack");

    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.CurrentState.Update();
        CheckForDashInput();
    }

    public void AnimationTrigger() => stateMachine.CurrentState.AnimationFinishTrigger();
    public void CheckForDashInput()
    {
        DashUseageTimer -= Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.LeftShift) && DashUseageTimer < 0)
        {

            DashUseageTimer = DashCooldown;
        DashDir = Input.GetAxisRaw("Horizontal");
        if (DashDir == 0)
            DashDir = FacingDir;

            stateMachine.ChangeState(dashState);

        }
    }







}
