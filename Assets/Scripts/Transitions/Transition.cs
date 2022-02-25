using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField]
    protected StateMachine _stateMachine;

    [SerializeField]
    protected State _destinationState;

    public virtual void Transit()
    {
        _stateMachine.SwitchState(_destinationState);
    }
}
