using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationLevelState : FinishedSelfState
{
    [Header("Menus")]
    [SerializeField]
    private DefeatMenu _defeatMenu;

    [SerializeField]
    private VictoryMenu _victoryMenu;

    [Space]

    [SerializeField]
    private List<Movable> _movables;

    [SerializeField]
    private WinCondition _winCondition;

    public override void Enter()
    {
        _winCondition.StartCheckResult();
        _winCondition.LevelEnd += OnLevelEnd;
      
        foreach (var movable in _movables)
        {
            movable.StartMove();
        }    
    }

    private void OnLevelEnd(LevelResult result)
    {
        _winCondition.LevelEnd -= OnLevelEnd;
        switch (result)
        {
            case LevelResult.Victory:
                _victoryMenu.Show();
                break;
            default:
                _defeatMenu.Show();
                break;
        }
        Exit();
    }

    public override void Exit()
    {
        foreach (var movable in _movables)
        {
            movable.StopMove();
        }
        _winCondition.StopCheckResults();
        base.Exit();
    }
}
