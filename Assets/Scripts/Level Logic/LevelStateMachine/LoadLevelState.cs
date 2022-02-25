using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class LoadLevelState : FinishedSelfState
{
    [Header("Initialization")]
    [SerializeField]
    private LevelConfig _currentLevel;

    [SerializeField]
    private RopeLimit _ropeLimit;

    [SerializeField]
    private VictoryMenu _victoryMenu;

    [SerializeField]
    private CinemachineVirtualCamera _startCamera;

    [SerializeField]
    private Control _control;

    public override void Enter()
    {
        _startCamera.gameObject.SetActive(true);
        Input.multiTouchEnabled = false;
        Rope.DisableCollisions();
        _ropeLimit.Init(_currentLevel);
        _victoryMenu.Init(_currentLevel);
        _control.Init(_currentLevel);
        Exit();
    }

}
