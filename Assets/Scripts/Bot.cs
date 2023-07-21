using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    public GameObject palette;
    private Transform _paletteTransform;
    private Vector3 _startingPosition;
    private Rigidbody _rigidbody;
    public float force = 3f;
    public float criticalModifier = 2f;
    
    private bool _tracking = false;
    private bool _critical = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;   
        _paletteTransform = palette.transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    
    private Vector3 _lastPosition = Vector3.zero;
    void Update()
    {
        if (!_tracking)
        {
            Vector3 directionStart = (_startingPosition - transform.position).normalized;
            if (!_tracking && Vector3.Distance(transform.position, _startingPosition) < 0.5f)
            {
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.angularVelocity = Vector3.zero;
                return;
            }
            _rigidbody.AddForce(directionStart * force);
            return;
        }
        
        Vector3 palettePosition = _paletteTransform.position;
        Vector3 direction;
        float forceModifier = 1f;
        if (!_critical)
        {
            if(_lastPosition == Vector3.zero) return;
            Vector3 trackingDirection = (palettePosition - _lastPosition).normalized;
            
            direction = (trackingDirection + (palettePosition - transform.position).normalized).normalized;
            _lastPosition = palettePosition;
        }
        else
        {
            forceModifier = criticalModifier;
            direction = (palettePosition - transform.position).normalized;
        }

        
        _rigidbody.AddForce(direction * (force * forceModifier));
    }
    
    public void SetTracking(bool status, bool critical)
    {
        if(critical) _critical = status;
        else
        {
            _tracking = status;
            _lastPosition = Vector3.zero;
        }
    }
}
