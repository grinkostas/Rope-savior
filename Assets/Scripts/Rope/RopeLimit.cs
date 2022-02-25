using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RopeLimit : MonoBehaviour
{
    [SerializeField]
    private Control _control;

    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private TextMeshProUGUI _avaliableText;

    private float _ropeLengthLimit = 0;
    private float _tempRopeLength;
    private float _usedRopeLength;
    public float RopeLengthAvaliable => _ropeLengthLimit - _usedRopeLength;

    private void OnEnable()
    {
        _control.NewRope += OnNewRope;
        _control.RemoveRope += OnRemoveRope;
    }

    private void OnDisable()
    {
        _control.NewRope -= OnNewRope;
        _control.RemoveRope -= OnRemoveRope;
    }

    public void StretchTempRope(float tempLenghth)
    {
        _tempRopeLength = tempLenghth;
        Actualize();
    }

    private void Actualize()
    {
        float value = RopeLengthAvaliable - _tempRopeLength;
        _slider.value = value / _ropeLengthLimit;
        _avaliableText.text = value.ToString() + "cm";
    }

    public void ResetLimit()
    {
        _usedRopeLength = 0;
        _tempRopeLength = 0;
        _slider.value = 1;
        Actualize();
    }

    public void OnNewRope(Rope rope)
    {
        _tempRopeLength = 0;
        _usedRopeLength += rope.Length;
        Actualize();
    }

    public void OnRemoveRope(Rope rope)
    {
        _tempRopeLength = 0;
        _usedRopeLength -= rope.Length;
        Actualize();
    }

    public void Init(LevelConfig config)
    {
        _ropeLengthLimit = config.MaxRopeLength;
        ResetLimit();
        Actualize();
    }
}
