using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFx : Fx
{
    [SerializeField]
    private AnimationCurve _curve;

    [SerializeField]
    private Transform _startPosition;

    [SerializeField]
    private Transform _destination;

    protected override void Frame(float progress)
    {
        Vector3 delta = _destination.position - _startPosition.position;
        _target.position = _startPosition.position + delta * _curve.Evaluate(progress);
    }



}
