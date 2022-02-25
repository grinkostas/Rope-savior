using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowElement : MonoBehaviour
{
    [SerializeField]
    private Transform _nextSpawnPoint;

    public Transform NextSpawnPoint => _nextSpawnPoint;
}
