using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZoneEnterCondition : WinCondition
{
    [SerializeField]
    private float _delayBetweenDefatMenu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            StartCoroutine(End());
        }
    }

    private IEnumerator End()
    {
        yield return new WaitForSeconds(_delayBetweenDefatMenu);
        EndLevel(LevelResult.Defeat);
    }
}
