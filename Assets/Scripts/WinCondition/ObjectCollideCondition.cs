using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


[RequireComponent(typeof(Rigidbody))]
public class ObjectCollideCondition : WinCondition
{
    [SerializeField]
    private Rigidbody _target;

    [SerializeField]
    private float _delayBetweenDefeat;


    private bool _isCollided = false;

    private void Collision()
    {
        if (_isCollided)
            return;

        StopCheckResults();
        _isCollided = true;
        StartCoroutine(DelayBetweenDefeat());
    }
    public override void StopCheckResults()
    {
        base.StopCheckResults();
        _isCollided = false;
    }

    private IEnumerator DelayBetweenDefeat()
    {
        yield return new WaitForSeconds(_delayBetweenDefeat / (1 / Time.timeScale));
        EndLevel(LevelResult.Defeat);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Collision();
        }
    }
}
