using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleColorRope : Rope
{
    [SerializeField]
    private Material[] _materials;

    [SerializeField]
    private int _oneColorCount;
    private int _colorsCount => _materials.Length;

    protected override RopeFragment GetRopeFragment(int i)
    {
        _ropePrefab.Renderer.material = _materials[GetIndex(i)];
        return _ropePrefab;
    }

    private int GetIndex(int i)
    { 
        return (i / _oneColorCount) % _colorsCount;
    }

}
