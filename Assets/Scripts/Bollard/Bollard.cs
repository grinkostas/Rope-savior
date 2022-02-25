using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bollard : MonoBehaviour
{
    [SerializeField]
    private List<ConnectPoint> _connectPoints;

    public Collider Collider => GetComponent<Collider>();
    public int MaxConnectinos => _connectPoints.Count;

    private int GetCurrentConnecions()
    {
        int count = 0;
        foreach (var item in _connectPoints)        
            if (item.Rope != null)            
                count++;
        return count;
    }

    public static bool IsAvaliableToConnect(Bollard start, Bollard end)
    {
        foreach (var item in start._connectPoints)
        {
            if (item.Rope == null)            
                continue;
            
            if (end._connectPoints.Contains(item.Rope.EndPoint))            
                return false;            
        }

        foreach (var item in end._connectPoints)
        {
            if (item.Rope == null)            
                continue;
            
            if (start._connectPoints.Contains(item.Rope.EndPoint))            
                return false;            
        }
        return true;
    }

    public bool TryGetFreeConnectPoint(out ConnectPoint connectPoint)
    {
        connectPoint = null;
        int currentConnections = GetCurrentConnecions();
        if (currentConnections >= MaxConnectinos)        
            return false;
        foreach (var item in _connectPoints)
        {
            if (item.Rope == null)
            {
                connectPoint = item;
                break;
            }
        }
        return true;
    }


}
