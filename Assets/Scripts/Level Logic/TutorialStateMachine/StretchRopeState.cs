using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StretchRopeState : FinishedSelfState
{
    [Space]

    [SerializeField]
    private Control _control;

    [SerializeField]
    private TutorialHint _tutorialHint;

    [SerializeField]
    private List<Bollard> _bollardsToEnable;

    [SerializeField]
    private List<Bollard> _bollardsToDisable;

    private void OnNewRope(Rope rope)
    {
        Exit();
    }


    public override void Enter()
    {
        foreach (var bollard in _bollardsToDisable)
            bollard.Collider.enabled = false;        

        foreach (var bollard in _bollardsToEnable)        
            bollard.Collider.enabled = true;
        
        _tutorialHint.gameObject.SetActive(true);
        _control.enabled = true;
        _control.NewRope += OnNewRope;
    }

    public override void Exit()
    {
        foreach (var bollard in _bollardsToDisable)
            bollard.enabled = true;

        _tutorialHint.gameObject.SetActive(false);
        _control.NewRope -= OnNewRope;
        _control.enabled = false;
        base.Exit();
    }
}
