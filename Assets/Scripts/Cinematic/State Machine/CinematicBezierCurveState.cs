using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CinematicBezierCurveState : CinematicState
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private BezierFx _bezierFx;

    [SerializeField]
    private float _time;


    private IEnumerator WaitCoroutine()
    {
        yield return _bezierFx.WaitAnimate(_time);
        Exit();
    }

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(WaitCoroutine());
    }

    public override void Exit()
    {
        base.Exit();
        StopCoroutine(WaitCoroutine());
    }
}
