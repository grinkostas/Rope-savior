using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RotationFx : Fx
{
    [SerializeField]
    protected AnimationCurve _curve;

    [SerializeField] 
    private Vector3 _startRotation;

    [SerializeField] 
    private Vector3 _destination;

    protected override void Frame(float progress)
    {
        Vector3 delta = _destination - _startRotation;
        _target.eulerAngles = _startRotation + delta * _curve.Evaluate(progress);
    }
  
}
