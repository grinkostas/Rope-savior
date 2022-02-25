using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBezier : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private BezierFx _fx;

    [SerializeField]
    private bool _activate;


    private void OnEnable()
    {
        _target.position = _fx.StartPosition;
    }

    private void Update()
    {
        if (_activate == true)
        {
            _activate = false;
            StartCoroutine(_fx.WaitAnimate(1));
        }
    }

}

