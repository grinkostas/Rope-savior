using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovable : Movable
{
    [SerializeField]
    private float _force;

    [SerializeField]
    private float _permanentSpeed;

    [SerializeField]
    private Vector3 _direction;

    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private MovableSound _sound;

    private bool _isMoving;

    private void Update()
    {
        if (_isMoving)                   
            Move();
        
    }

    private void Move()
    {
        _rigidbody.velocity += _direction * _permanentSpeed * Time.deltaTime;
    }
 

    public override void StopMove()
    {
        if (_sound != null)
        {
            _sound.Pause();
        }
        _isMoving = false;
    }


    public override void StartMove()
    {
        if (_isMoving == true)
            return;

        if (_sound != null)
        {
            _sound.Play();
        }

        StopMove();
        _rigidbody.velocity += _force * _direction;
        _isMoving = true;
    }
}
