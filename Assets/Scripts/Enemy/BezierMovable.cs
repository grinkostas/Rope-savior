using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierMovable : Movable
{
    [SerializeField]
    private BezierFx _bezierFx;

    [SerializeField]
    private RotationFx _rotationFx;

    [SerializeField]
    private float _time;

    [SerializeField]
    private Rigidbody _target;

    [SerializeField]
    private float _force;

    [SerializeField]
    private float _permanentForce;

    private bool _isFxEnd = false;

    private void OnEnable()
    {
        _target.useGravity = false;
    }

    private void Update()
    {
        if (_isFxEnd)
            _target.velocity += Vector3.down * Time.deltaTime *_permanentForce;
    }
    public override void StartMove()
    {
        StartCoroutine(Move());
        StartCoroutine(Rotate());
    }

    public override void StopMove()
    {
        StopCoroutine(Move());
        StopCoroutine(Rotate());

        _target.useGravity = true;
        _target.velocity += Vector3.down * _force;
        _isFxEnd = true;
    }

    private IEnumerator Move()
    {

        yield return _bezierFx.WaitAnimate(_time);
        StopMove();
    }

    private IEnumerator Rotate()
    {
        yield return _rotationFx.WaitAnimate(_time);
    }

}
