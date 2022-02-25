using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectPoint : MonoBehaviour
{
    [SerializeField]
    private Joint _joint;

    [SerializeField]
    private Rigidbody _rigidbody;

    public Rope Rope { get; private set; }

    public void InitRope(Rigidbody ropeRigidbody)
    {
        _joint.connectedBody = ropeRigidbody;        
    }

    public static void Connect(ConnectPoint start, ConnectPoint end, Rope rope)
    {
        rope.RopeFragments[rope.RopeFragments.Count - 1].Joint.connectedBody = end._rigidbody;
        start.Rope = rope;
        end.Rope = rope;
    }

    public void DeleteRope()
    {
        Rope = null;
    }
}
