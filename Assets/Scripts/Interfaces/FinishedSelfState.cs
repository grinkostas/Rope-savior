using UnityEngine;
using UnityEngine.Events;

public abstract class FinishedSelfState : State
{
    [Header("Machine")]
    [SerializeField]
    protected StateMachine _stateMachine;

    [SerializeField]
    private State _nextState;

    public override void Exit()
    {
        _stateMachine.SwitchState(_nextState, true);
    }
}
