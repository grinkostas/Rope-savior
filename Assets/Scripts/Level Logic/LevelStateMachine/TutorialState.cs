using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialState : FinishedSelfState
{
    [SerializeField]
    private TutorialStateMachine _tutorial;
    public override void Enter()
    {
        _tutorial.StartMachine();
        _tutorial.Finished += Exit;
    }

    public override void Exit()
    {
        _tutorial.Finished -= Exit;
        base.Exit();
    }
}
