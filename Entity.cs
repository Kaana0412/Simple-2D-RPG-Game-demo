using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public EntityFX fx { get; private set; }

    protected bool FacingRight = true;
    public int FacingDir { get; private set; } = 1;

    [Header("Attack details")]
    public Transform attackCheck;
    public float attackCheckRadius;

    [Header("Knockback info")]
    [SerializeField] protected Vector2 knockbackDir;
    protected bool isKnocked;

    [Header("Collision info")]
    [SerializeField] protected Transform GroundCheck;
    [SerializeField] protected float GroundCheckDistence;
    [SerializeField] protected Transform WallCheck;
    [SerializeField] protected float WallCheckDistence;
    [SerializeField] protected LayerMask WhatIsGround;
    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        fx = GetComponentInChildren<EntityFX>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {

    }
    #region Velocity
    public void SetVelocity(float _xvelocity, float _yvelocity)
    {
        if (isKnocked)
            return;
        rb.velocity = new Vector2(_xvelocity, _yvelocity);
        FlipController(_xvelocity);
    }
    #endregion
    #region Collision
    public virtual bool isGroundDetected() => Physics2D.Raycast(GroundCheck.position, Vector2.down, GroundCheckDistence, WhatIsGround);
    public  virtual bool isWallDetected() => Physics2D.Raycast(WallCheck.position, Vector2.right * FacingDir, WallCheckDistence, WhatIsGround);
    protected  virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(GroundCheck.position, new Vector3(GroundCheck.position.x, GroundCheck.position.y - GroundCheckDistence));
        Gizmos.DrawLine(WallCheck.position, new Vector3(WallCheck.position.x - WallCheckDistence, WallCheck.position.y));
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    #endregion
    #region Flip
    public virtual void Flip()
    {
        FacingDir *= -1;
        FacingRight = !FacingRight;
        transform.Rotate(0, 180, 0);
    }
    public virtual void Damage()
    {
        fx.StartCoroutine("FlashFX");
        StartCoroutine("HitKnockback");
    }

    protected virtual IEnumerator HitKnockback()
    {
        isKnocked = true;
        rb.velocity = new Vector2(knockbackDir.x * -FacingDir, knockbackDir.y);
        yield return new WaitForSeconds(0.07f);
        isKnocked = false;
    }

    public virtual void FlipController(float _x)
    {
        if (FacingRight && _x < 0)
        {
            Flip();
        }
        else if (!FacingRight && _x > 0)
        {
            Flip();
        }
    }
    #endregion
}
