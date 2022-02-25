using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class CinematicLevelState : FinishedSelfState
{
    [Space]

    [SerializeField]
    private TapToStartMenu _tapToStartMenu;

    [SerializeField]
    protected CinematicStateMachine _cinematicStateMachine;

    private void StartState()
    {
        _tapToStartMenu.Hide();
        _cinematicStateMachine.StartMachine();
    }

    public override void Enter()
    {
        _tapToStartMenu.Show();
        _cinematicStateMachine.Finished += Exit;
        _tapToStartMenu.Start += StartState;
    }

    public override void Exit()
    {
        _cinematicStateMachine.Finished -= Exit;
        _tapToStartMenu.Start -= StartState;
        _cinematicStateMachine.StopMachine();
        _tapToStartMenu.Hide();
        base.Exit();
    }
}
