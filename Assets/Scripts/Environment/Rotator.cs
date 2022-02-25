using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private Vector3 _rotationAxes;

    [SerializeField]
    private float _anglePerSecond;

    [SerializeField]
    private bool _defaultStart = true;

    private bool _isRotate;

    private void OnEnable()
    {        
        _isRotate = _defaultStart;        
    }

    private void OnDisable()
    {
        _isRotate = false;
    
    }
    private void Update()
    {
        if (_isRotate)        
            Rotate();
        
    }
    public void StartRotation()
    {
        _isRotate = true;
    }

    private void Rotate()
    {
        float speed = _anglePerSecond * Time.deltaTime;
        transform.Rotate(_rotationAxes * speed);
    }

 
}
