using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowSpawner : MonoBehaviour
{
    [SerializeField]
    private RowElement _rowElement;

    [SerializeField]
    private Quaternion _rotation;

    [SerializeField]
    private int _count;

    [SerializeField]
    private bool _showInEditor;

    private List<RowElement> _rowElements = new List<RowElement>();


    private void OnValidate()
    {
        if (_showInEditor)
        {
            _showInEditor = false;
            Spawn();
        }
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        DestroyAll();
        Vector3 position = transform.position;
        for (int i = 0; i < _count; i++)
        {
            RowElement element = Instantiate(_rowElement, position, _rotation, transform);
            _rowElements.Add(element);
            position = element.NextSpawnPoint.position;
        }
    }

    private void DestroyAll()
    {
        foreach (var element in _rowElements)
        {
            Destroy(element.gameObject);
        }
        _rowElements.Clear();
    }
}
