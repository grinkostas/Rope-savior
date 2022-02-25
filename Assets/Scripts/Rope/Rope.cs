using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rope : MonoBehaviour
{
    [SerializeField]
    protected RopeFragment _ropePrefab;

    [SerializeField]
    private float _breakTime;

    [SerializeField]
    private float _breakDurability;

    private List<RopeFragment> _ropeFragments = new List<RopeFragment>();
    private Vector3 _spawnPosition;

    public List<RopeFragment> RopeFragments => _ropeFragments;

    public ConnectPoint StartPoint { get; private set; }
    public ConnectPoint EndPoint { get; private set; }
       
    public float Length => _ropeFragments.Count * _ropePrefab.Joint.transform.localScale.z;

    private float _currentDurabity;

    private bool _broke = false;

    private void Stretch(Vector3 start, Vector3 destination)
    {
        int count = GetFragmentsCount(start, destination);
        for (int i = 0; i < count; i++)
        {
            var fragment = SpawnRopeFragment(GetAngles(start, destination), i);
        }      
    }

    private int GetFragmentsCount(Vector3 start, Vector3 destination)
    {
        float distance = (destination - start).magnitude;
        _spawnPosition = start;
        float count = distance / _ropePrefab.Joint.transform.localScale.z;

        return (int)Mathf.Ceil(count);
    }

    private RopeFragment SpawnRopeFragment(Quaternion angles, int i)
    {
        var fragment = Instantiate(GetRopeFragment(i), _spawnPosition, angles, transform);
        fragment.Init(this);
        if (i > 0)
            _ropeFragments[i - 1].Joint.connectedBody = fragment.Rigidbody;
        _spawnPosition = fragment.NextSpawnPoint.position;
        _ropeFragments.Add(fragment);
        return fragment;
    }

    protected virtual RopeFragment GetRopeFragment(int i)
    {
        return _ropePrefab;
    }

    private Quaternion GetAngles(Vector3 start, Vector3 destination)
    {        
        return Quaternion.Euler(0, GetYAngle(start, destination), 0);
    }

    private float GetYAngle(Vector3 start, Vector3 destination)
    {        
        float aDistance = Mathf.Abs(destination.x - start.x);
        float bDistance = Mathf.Abs(destination.z - start.z);

        float tanAngle = Mathf.Atan(aDistance / bDistance) * Mathf.Rad2Deg;
        float tanAdditional = 0, tanMultiplayer = 1;

        if (destination.x > start.x)
        {
            if (destination.z < start.z)
                tanAdditional = 180 - tanAngle * 2;
        }
        else
        {
            if (destination.z > start.z)
                tanMultiplayer = -1;
            else
                tanAdditional = 180;
        }

        float result = tanAngle * tanMultiplayer + tanAdditional;
        return result;
    }

    private void ResetRope()
    {
        foreach (var fragment in _ropeFragments)
        {
            Destroy(fragment.gameObject);
        }
        _ropeFragments.Clear();
    }

    private void Connect(ConnectPoint start, ConnectPoint destination)
    {
        _currentDurabity = _breakDurability;
        StartPoint = start; EndPoint = destination;
        ConnectPoint.Connect(start, destination, this);
        
    }

    public void Draw(ConnectPoint start, Vector3 destination)
    {
        ResetRope();
        Stretch(start.transform.position, destination);
        start.InitRope(_ropeFragments[0].Rigidbody);
    }

    public void Draw(ConnectPoint start, ConnectPoint end)
    {
        Draw(start, end.transform.position);
        Connect(start, end);
    }

    public static void DisableCollisions()
    {
        Physics.IgnoreLayerCollision(6, 6, true);
    }

    private IEnumerator Break()
    {
        if (_broke)        
            yield break;
        
        yield return new WaitForSeconds(_breakTime);

        _broke = true;
        var joint = _ropeFragments[_ropeFragments.Count / 2].Joint;
        if (_ropeFragments[_ropeFragments.Count / 2] == null)
        {
            yield break;
        }
        _ropeFragments[_ropeFragments.Count / 2].Joint.connectedBody = null;
        Destroy(_ropeFragments[_ropeFragments.Count / 2].gameObject);
    }

    public void Break(ref float breakForce)
    {
        if (_broke == false)
        {
            float durabilityDamage = breakForce;
            if (_breakDurability < breakForce)
            {
                durabilityDamage = _breakDurability;
            }
            breakForce -= durabilityDamage;
            _breakDurability -= durabilityDamage;
        }

        if (_breakDurability <= 0)
        {
            StartCoroutine(Break());
        }
    }



}
