using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Info")]
    public float movespeed;

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D Rb { get; private set; }

    #endregion
    
    #region States
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }

    public PlayerMoveState moveState { get; private set; }

    #endregion

    public void Awake()
    {
        StateMachine = new PlayerStateMachine();

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
    }
}
