using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineFinishTransition : Transition
{
    [SerializeField]
    private FinishedSelfStateMachine _finishableStateMachine;

    private void OnEnable()
    {
        _finishableStateMachine.Finished += Transit;
    }

    private void OnDisable()
    {
        _finishableStateMachine.Finished -= Transit;
    }
}
