using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class RopeMenu : Menu
{
    [SerializeField]
    private TextMeshProUGUI _legthText;

    [SerializeField]
    private Control _control;

    [SerializeField]
    private string _units;

    private Rope _rope;

    public bool IsHidden { get; private set; }

    private void Awake()
    {
        Hide();
    }

    private void Update()
    {
        if (_rope != null)
            ChangePosition();
    }
    private void ChangePosition()
    {
        var middleFragment = _rope.RopeFragments[_rope.RopeFragments.Count / 2];
        transform.position = middleFragment.Joint.transform.position;
    }
    public override void Hide()
    {
        base.Hide();
        IsHidden = true;
    }

    public override void Show()
    {
        base.Show();
        IsHidden = false;
    }
    public void Show(Rope rope)
    {
        if (rope == null)
        {
            return;
        }
        _rope = rope;
        _legthText.text = rope.Length.ToString() + _units;
        ChangePosition();
        Show();
    }

    public void Click()
    {
        _control.DeleteRope(_rope);
        _rope = null;        
        Hide();
    }


}
