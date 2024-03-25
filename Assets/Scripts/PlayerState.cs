using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    protected Rigidbody2D rb;

    protected float xInput;
    private string animBoolName;

    public PlayerState(PlayerStateMachine _stateMachine, Player _palyer, string _animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.player = _palyer;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter() 
    {
        player.anim.SetBool(animBoolName, true);
        rb = player.Rb;
    }
    
    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        player.anim.SetFloat("yVelocity", rb.velocity.y);
    }
    
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }
}
