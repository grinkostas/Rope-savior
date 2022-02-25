using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fx : MonoBehaviour
{

    [SerializeField]
    protected Transform _target;

    public void Animate(float time)
    {
        StartCoroutine(FrameAnimate(time));
    }

    public IEnumerator WaitAnimate(float time)
    {
        yield return FrameAnimate(time);
    }

    protected abstract void Frame(float progress);

    public IEnumerator FrameAnimate(float time)
    {
        if (time <= 0)
            yield break;

        float progress = 0;
        float wastedTime = 0;

        while (progress <= 1)
        {
            progress = wastedTime / time;
            Frame(progress);
            wastedTime += Time.deltaTime;
            yield return null;

        }
    }
}
