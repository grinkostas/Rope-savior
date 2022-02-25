using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFx : Fx
{
    [SerializeField]
    private BezierCurve _bezierCurve;

    public Vector3 StartPosition => _bezierCurve.Evaluate(0);

    protected override void Frame(float progress)
    {
        _target.position = _bezierCurve.Evaluate(progress);
    }
}
