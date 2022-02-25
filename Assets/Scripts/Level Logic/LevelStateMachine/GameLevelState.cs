using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameLevelState : State
{
    [SerializeField]
    private CinemachineVirtualCamera _mainCamera;

    [SerializeField]
    private Control _control;

    [SerializeField]
    private LevelUIMenu _levelUIMenu;

    [SerializeField]
    private List<Reseter> _resetables;

    public override void Enter()
    {
        _control.ResetContorol();
        foreach (var resetable in _resetables)
            resetable.Reset();
        
        _mainCamera.gameObject.SetActive(true);
        _levelUIMenu.Show();
        _control.enabled = true;
    }

    public override void Exit()
    {
        _levelUIMenu.Hide();
        _control.enabled = false;

    }





}
