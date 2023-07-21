using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotArea : MonoBehaviour
{
    public GameObject palette;
    private Collider _paletteCollider;
    
    public GameObject bot;
    private Bot _botScript;

    private void Start()
    {
        _paletteCollider = palette.GetComponent<Collider>();
        _botScript = bot.GetComponent<Bot>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == _paletteCollider)
            _botScript.SetTracking(true);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other == _paletteCollider)
            _botScript.SetTracking(false);
    }
}
