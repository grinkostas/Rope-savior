using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIMenu : Menu
{
    [SerializeField]
    private Control _control;

    [SerializeField]
    private Button _readyButton;

    public Button ReadyButton => _readyButton;

    private void OnEnable()
    {
        HideButton();
        _control.NewRope += OnNewRope;
    }

    private void OnDisable()
    {
        _control.NewRope -= OnNewRope;
    }

    public void ShowButton()
    {
        _readyButton.gameObject.SetActive(true);
    }
    public void HideButton()
    {
        _readyButton.gameObject.SetActive(false);
    }

    public void OnNewRope(Rope rope)
    {
        ShowButton();
        _control.NewRope -= OnNewRope;
    }
}
