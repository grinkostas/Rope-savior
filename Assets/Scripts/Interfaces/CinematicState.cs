using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public abstract class CinematicState : FinishedSelfState
{
    [SerializeField]
    protected CinemachineVirtualCamera _actionCamera;

    public override void Enter()
    {
        _actionCamera.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        _actionCamera.gameObject.SetActive(false);
    }
}
