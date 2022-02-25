using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class TransformReseter : Reseter
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private Transform _startPoint;

    private void ResetPosition(Transform target)
    {
        target.position = _startPoint.position;
        target.rotation = _startPoint.rotation;
    }

    public override void Reset()
    {
        ResetPosition(_target);
    }
}

