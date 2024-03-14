using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player palyer;

    private string animBoolName;

    public PlayerState(PlayerStateMachine _stateMachine, Player _palyer, string _animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.palyer = _palyer;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter() 
    {

    }
    
    public virtual void Update()
    {

    }
    
    public virtual void Exit()
    {

    }
}
