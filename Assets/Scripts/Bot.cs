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
    private bool _tracking = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;   
        _paletteTransform = palette.transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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

        Vector3 direction = (palettePosition - transform.position).normalized;
        
        _rigidbody.AddForce(direction * force);
        
    }
    
    public void SetTracking(bool tracking)
    {
        _tracking = tracking;
    }
}
