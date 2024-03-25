using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(PlayerStateMachine _stateMachine, Player _palyer, string _animBoolName) : base(_stateMachine, _palyer, _animBoolName)
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

        if(Input.GetKeyDown(KeyCode.Space) && player.IsGroundDetected()) 
        {
            stateMachine.ChangeState(player.jumpState);
        }
    }
}
