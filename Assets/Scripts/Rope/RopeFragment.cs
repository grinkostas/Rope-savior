using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeFragment : MonoBehaviour
{
    [SerializeField]
    private Transform _nextSpawnPoint;

    [SerializeField]
    private Joint _joint;

    [SerializeField]
    private Renderer _renderer;

    public Rope Rope { get; private set; }
    public Renderer Renderer => _renderer;
    public Transform NextSpawnPoint => _nextSpawnPoint;
    public Joint Joint => _joint;
    public Rigidbody Rigidbody => _joint.gameObject.GetComponent<Rigidbody>();

    public void Init(Rope rope)
    {
        Rope = rope;
    }
}
