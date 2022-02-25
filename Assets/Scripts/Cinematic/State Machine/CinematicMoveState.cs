using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CinematicMoveState : CinematicState
{
    [Header("Move Settings")]
    [SerializeField]
    private float _time;

    [SerializeField]
    private Fx _fx;
 
    private IEnumerator WaitCoroutine()
    {
        yield return _fx.WaitAnimate(_time);
        Exit();
    }

    public override void Enter() 
    {
        base.Enter();
        StartCoroutine(WaitCoroutine());
    }
}
