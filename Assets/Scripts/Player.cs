using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Info")]
    public float movespeed;
    public float jumpforce;

    [Header("Collison Info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallChcekDistance;
    [SerializeField] private LayerMask WhatIsGround;

    public int Dir { get; private set; } = 1;
    private bool facingRight = true;
    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D Rb { get; private set; }

    #endregion
    
    #region States
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }

    public PlayerMoveState moveState { get; private set; }

    public PlayerJumpState jumpState { get; private set; }

    public PlayerAirState airState { get; private set; }

    #endregion

    public void Awake()
    {
        StateMachine = new PlayerStateMachine();

        airState = new PlayerAirState(this, StateMachine, "Jump");
        jumpState = new PlayerJumpState(this, StateMachine, "Jump");
        idleState = new PlayerIdleState(this, StateMachine, "Idle");
        moveState = new PlayerMoveState(this, StateMachine, "Move");
    }

    public void Start()
    {
        anim = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(idleState);
    }

    private void Update()
    {
        StateMachine.currentState.Update();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        Rb.velocity = new Vector2 (xVelocity, yVelocity);
        FlipControler(xVelocity);
    }

    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, WhatIsGround);
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallChcekDistance, wallCheck.position.y)); 
    }

    public void Flip()
    {
        Dir *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    public void FlipControler(float _x)
    {
        if (_x > 0 && !facingRight) Flip();
        else if (_x < 0 && facingRight) Flip();
    }
}
