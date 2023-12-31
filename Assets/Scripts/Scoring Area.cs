using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringArea : MonoBehaviour
{
    public int associatedPlayer;
    public GameObject palette;
    private ScoringManager _scoringManager;
    public Transform respawn;
    
    public void SetScoringManager(ScoringManager scoringManager)
    {
        _scoringManager = scoringManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == palette)
        {
            _scoringManager.AddScore(associatedPlayer);
            palette.transform.position = respawn.position;
            Rigidbody rb = palette.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
    
}
