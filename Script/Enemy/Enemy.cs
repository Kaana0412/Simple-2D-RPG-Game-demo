using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField]protected LayerMask whatIsPlayer;

    [Header("Stunned info")]
    public float stunDuration;
    public Vector2 stunDirection;
    protected bool canBeStunned;
    [SerializeField] protected GameObject counterImage;

    [Header("Move info")]
    public float moveSpeed;
    public float idleTime;
    public float battleTime;

    [Header("Attack info")]
    public float attackDistance;
    public float attackCoolDown;
    public float lastAttackTime;

    public EnemyStateMachmine StateMachmine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        StateMachmine = new EnemyStateMachmine();
    }

    protected override void Update()
    {
        base.Update();
        StateMachmine.CurrentState.Update();
    }

    public virtual void OpenCounterAttackWindow()
    {
        canBeStunned = true;
        counterImage.SetActive(true);
    }

    public virtual void CloseCounterAttackWindow()
    {
        canBeStunned = false;
        counterImage.SetActive(false);
    }

    public virtual bool CanBeStunned()
    {
        if (canBeStunned)
        {
            CloseCounterAttackWindow();
            return true;
        }
        return false;   
    }

    public virtual void AnimationFinishTrigger() => StateMachmine.CurrentState.AnimationFinishTrigger();
    public virtual RaycastHit2D IsPlayerDetcted() => Physics2D.Raycast(WallCheck.position, Vector2.right * FacingDir, 20, whatIsPlayer);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawLine(transform.position,new Vector3(transform.position.x + attackDistance * FacingDir, transform.position.y));
    }
}
