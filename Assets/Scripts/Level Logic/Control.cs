using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Control : MonoBehaviour
{
    [SerializeField]
    private RopeMenu _ropeMenu;

    [SerializeField]
    private RopeLimit _ropeLimit;

    [SerializeField]
    private float _delayBetweenRopes = 0.1f;

    private Rope _ropePrefab;
    private ConnectPoint _startConnectPoint;
    private Bollard _startBollard;

    private Rope _currentRope;
    private List<Rope> _ropes = new List<Rope>();

    public UnityAction<Rope> NewRope;
    public UnityAction<Rope> RemoveRope;

    private bool _isMoving = false;

    private void Update()
    {
        if (_ropePrefab == null)
            return;

        Click();
    }
    private void Click()
    {
        if (Input.GetKey(KeyCode.Mouse0) == false)
        {
            _isMoving = false;
            return;
        }

        if (Input.touchSupported)
        {
            if (Input.touchCount <= 0)
                return;

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
                _isMoving = false;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) == false)
            return;

        if (TryClickOnBollard(hit))              
            return;
        
        if (TryClickOnPlane(hit))            
            return;

        if (Input.GetMouseButtonDown(0) && _currentRope == null)        
            if (TryClickOnRope(hit))
                return;

    }
    
    private bool TryClickOnPlane(RaycastHit raycastHit)
    {
        if (raycastHit.collider.TryGetComponent(out TouchZone zone) == false || _startConnectPoint == null)        
            return false;

        float distance = Vector3.Distance(raycastHit.point, _startConnectPoint.transform.position);
        Vector3 endPoint = raycastHit.point;
        if (distance > _ropeLimit.RopeLengthAvaliable)
        {
            float t = _ropeLimit.RopeLengthAvaliable / distance;
            endPoint = (1 - t) * _startConnectPoint.transform.position + t * raycastHit.point;
        }

        _currentRope.Draw(_startConnectPoint, endPoint);
        _ropeLimit.StretchTempRope(_currentRope.Length);
        return true;
    }

    private bool TryClickOnBollard(RaycastHit raycastHit)
    {      

        Bollard bollard;
        if (raycastHit.collider.TryGetComponent(out bollard) == false)        
            return false;

        _ropeMenu.Hide();

        if (_startConnectPoint == null)
        {
            if (_isMoving)            
                return true;
            
            _startBollard = bollard;
            if (bollard.TryGetFreeConnectPoint(out _startConnectPoint) == false)            
                return true;
            
            _currentRope = Instantiate(_ropePrefab, transform);
            _isMoving = true;
            return true;
        }

        
        if (bollard == _startBollard)
        {
            return false;
        }
        
        ConnectPoint endPoint;
        if (bollard.TryGetFreeConnectPoint(out endPoint) == false)
        {
            return true;
        }
        if (Bollard.IsAvaliableToConnect(_startBollard, bollard))
        {
            float distance = Vector3.Distance(endPoint.transform.position, _startConnectPoint.transform.position);
            if (_ropeLimit.RopeLengthAvaliable < distance)
            {
                return true;
            }
            _currentRope.Draw(_startConnectPoint, endPoint);

            NewRope?.Invoke(_currentRope);
            _ropes.Add(_currentRope);
            ResetCurrentRope();
        }

        return true;
    }


    private bool TryClickOnRope(RaycastHit raycastHit)
    {
        Rope rope = null;
        RopeFragment ropeFragment;
        if (raycastHit.collider.TryGetComponent(out ropeFragment) == false)
            return false;

        if (_ropeMenu.IsHidden == false)
        {
            _ropeMenu.Hide();
            return true;
        }

        foreach (var item in _ropes)
        {
            if (item.RopeFragments.Contains(ropeFragment))
            {
                rope = item;
                break;
            }
        }

        _ropeMenu.Show(rope);
        
        return true;
    }


    private void ResetCurrentRope()
    {
        _currentRope = null;
        _startConnectPoint = null;
        _startBollard = null;
    }

    private void RemoveAllRopes()
    {
        foreach (var rope in _ropes)
        {
            DeleteRope(rope);            
        }
        _ropes.Clear();
        ResetCurrentRope();
    }

    public void Init(LevelConfig config)
    {
        _ropePrefab = config.RopePrefab;
    }

    public void ResetContorol()
    {
        RemoveAllRopes();
        _ropeLimit.ResetLimit();
    }

    public void DeleteRope(Rope rope)
    {
        RemoveRope?.Invoke(rope);
        if (rope.StartPoint != null)
            rope.StartPoint.DeleteRope();

        if (rope.EndPoint != null)
            rope.EndPoint.DeleteRope();

        Destroy(rope.gameObject);
    }

}

