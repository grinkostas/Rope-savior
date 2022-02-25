using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TapToStartMenu : Menu
{
    public UnityAction Start;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Start?.Invoke();
        }
    }
}
