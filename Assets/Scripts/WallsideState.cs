using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsideState : PlayerState
{
    public WallsideState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
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

        if (xInput != 0 && player.Dir != xInput)
            stateMachine.ChangeState(player.idleState);
        if (yInput < 0)
            rb.velocity = new Vector2(0, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y * .1f);
        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}