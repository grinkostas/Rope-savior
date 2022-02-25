using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCinematicState : State
{
    [SerializeField]
    private CinematicStateMachine _stateMachine;

    public override void Enter()
    {
        _stateMachine.Finished?.Invoke();
    }

    public override void Exit()
    {
        
    }
}
