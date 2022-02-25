using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _bezierPoints;

    [SerializeField]
    [Range(0.02f, 1)] 
    private float _step;

    [SerializeField]
    private float _gizmosSize;

    [SerializeField]
    private float _lineWidth;

    [SerializeField]
    private bool _showInEditor;

    private void OnDrawGizmos()
    {
        if (_bezierPoints.Count < 4 || _showInEditor == false)
            return;

        for (float t = 0; t <= 1; t += _step)
        {
            Gizmos.DrawSphere(Evaluate(t), _gizmosSize);
        }
        

        Gizmos.DrawLine(_bezierPoints[0].position, _bezierPoints[1].position);
        Gizmos.DrawLine(_bezierPoints[2].position, _bezierPoints[3].position);
    }

    public Vector3 Evaluate(float t)
    {
        return Mathf.Pow(1 - t, 3) * _bezierPoints[0].position 
            + 3 * t * Mathf.Pow(1 - t, 2) * _bezierPoints[1].position
            + 3 * Mathf.Pow(t, 2) * (1 - t) * _bezierPoints[2].position
            + Mathf.Pow(t, 3) * _bezierPoints[3].position ;
    }
}
