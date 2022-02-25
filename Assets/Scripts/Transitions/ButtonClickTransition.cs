using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickTransition : Transition
{
    [Space]

    [SerializeField]
    private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(Transit);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Transit);
    }


}
