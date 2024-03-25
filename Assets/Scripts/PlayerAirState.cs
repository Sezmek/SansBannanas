using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState( Player _palyer, PlayerStateMachine _stateMachine, string _animBoolName) : base(_stateMachine, _palyer, _animBoolName)
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
        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
