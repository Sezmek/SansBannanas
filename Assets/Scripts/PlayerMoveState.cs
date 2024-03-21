using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState( Player _palyer, PlayerStateMachine _stateMachine, string _animBoolName) : base(_stateMachine, _palyer, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(xInput * player.movespeed, rb.velocity.y);
        if (xInput == 0)
            stateMachine.ChangeState(player.idleState);
    }
}
