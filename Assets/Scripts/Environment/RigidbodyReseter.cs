using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyReseter : Reseter
{
    [SerializeField]
    private Rigidbody _target;

    [SerializeField]
    private Transform _startPoint;
    private void ResetPosition(Transform target)
    {
        target.position = _startPoint.position;
        target.rotation = _startPoint.rotation;
    }

    private RigidbodyConstraints _constraints;

    private void StopMove()
    {
        if (_target == null)
            return;
        _constraints = _target.constraints;
        _target.constraints = RigidbodyConstraints.FreezeAll;
        _target.velocity = Vector3.zero;
    }

    private void EnableMove()
    {
        _target.constraints = _constraints;
    }

    private void MoveToStartPoint()
    {
        StopMove();
        ResetPosition(_target.transform);
        EnableMove();
    }

    public override void Reset()
    {
        MoveToStartPoint();
    }
}
