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
    public float force = 10f;
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
        Vector3 palettePosition = _paletteTransform.position;
        
        Vector3 target;
        if(_tracking) target = palettePosition;
        else target = _startingPosition;

        Vector3 direction = (target - transform.position).normalized;
        
        if (!_tracking && Vector3.Distance(transform.position, _startingPosition) < 0.5f)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            return;
        }
        
        _rigidbody.AddForce(direction * force);
    }
    
    public void SetTracking(bool tracking)
    {
        _tracking = tracking;
    }
}
