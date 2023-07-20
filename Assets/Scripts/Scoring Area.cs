using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringArea : MonoBehaviour
{
    public int associatedPlayer;
    public GameObject palette;
    private ScoringManager _scoringManager;
    
    // Start is called before the first frame update
    public void SetScoringManager(ScoringManager scoringManager)
    {
        _scoringManager = scoringManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GOAAAAAAAAAL");
        if(other.gameObject == palette)
            _scoringManager.AddScore(associatedPlayer);
    }
    
}
