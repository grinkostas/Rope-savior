using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTutorialState : LastState
{
    [SerializeField]
    private LevelUIMenu _menu;

    private Button _button;

    public override void Enter()
    {
        _button = _menu.ReadyButton;
        _menu.Show();
        _menu.ShowButton();
        _button.onClick.AddListener(Exit);
    }

    public override void Exit()
    {
        _menu.Hide();
        _menu.HideButton();
        _button.onClick.RemoveListener(Exit);
        base.Exit();
    }
}
