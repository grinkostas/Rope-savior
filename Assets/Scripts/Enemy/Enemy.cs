using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Enemy : RigidbodyReseter
{
    [SerializeField]
    private float _breakForce;


    private float _currentForce;

    private void Awake()
    {
        _currentForce = _breakForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out RopeFragment ropeFragment))
        {
            ropeFragment.Rope.Break(ref _currentForce);
        }
        
    }

    public override void Reset()
    {
        base.Reset();
        _currentForce = _breakForce;
        
    }
}
