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
        
        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, palettePosition, NavMesh.AllAreas, path);

        Vector3 target;
        
        if (path.status == NavMeshPathStatus.PathPartial) target = _startingPosition;
        else target = palettePosition;
        
        Vector3 direction = (target - transform.position).normalized;
        
        _rigidbody.AddForce(direction * force);
    }
}
