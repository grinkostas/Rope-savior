using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class StateMachine : MonoBehaviour
{
    [SerializeField]
    protected State _firstState;

    protected State _currentState = null;

    public virtual void StartMachine()
    {
        SwitchState(_firstState);
    }

    public virtual void StopMachine()
    {
        if (_currentState != null)
        {
            _currentState = null;
        }
    }
    
    public virtual void SwitchState(State state, bool onStateExit = false)
    {
        if (_currentState != null && onStateExit == false)
        {
            _currentState.Exit();
        }

        _currentState = state;
        _currentState.Enter();
    }
}
