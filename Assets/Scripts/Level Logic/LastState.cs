using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LastState : State
{
    [SerializeField]
    protected StateMachine _stateMachine;

    public override void Exit()
    {
        _stateMachine.StopMachine();
    }
}
