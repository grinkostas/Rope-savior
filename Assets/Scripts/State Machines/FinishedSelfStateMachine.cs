using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;


public abstract class FinishedSelfStateMachine : StateMachine
{
    public UnityAction Finished;

    public override void StopMachine()
    {
        base.StopMachine();
        Finished?.Invoke();
    }
}

