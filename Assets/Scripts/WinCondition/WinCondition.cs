using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class WinCondition : MonoBehaviour
{
    [SerializeField]
    private float _checkingTime;

    private LevelResult _levelResult = LevelResult.None;

    public UnityAction<LevelResult> LevelEnd;

    private IEnumerator CheckResult()
    {
        yield return new WaitForSeconds(_checkingTime);
        if (_levelResult == LevelResult.None )
            EndLevel(LevelResult.Victory);
    }

    protected void EndLevel(LevelResult result)
    {
        _levelResult = result;
        LevelEnd?.Invoke(_levelResult);
        StopCheckResults();
    }


    public virtual void StopCheckResults()
    {
        StopCoroutine(CheckResult());
    }

    public virtual void StartCheckResult()
    {
        if (gameObject.activeSelf)
        {
            StopCoroutine(CheckResult());
            _levelResult = LevelResult.None;
            StartCoroutine(CheckResult());
        }
        
    }

}
