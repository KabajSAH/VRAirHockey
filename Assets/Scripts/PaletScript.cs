using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PaletScript : MonoBehaviour
{

    public GameObject palette;
    public float multiplier;
    private Rigidbody _rbPalette;

    private void Start()
    {
        _rbPalette = palette.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == palette)
        {

            Vector3 force = palette.transform.position - transform.position;
            force.y = 0;
            force.Normalize();
            
            _rbPalette.AddForce(force * multiplier);
        }
    }
}
