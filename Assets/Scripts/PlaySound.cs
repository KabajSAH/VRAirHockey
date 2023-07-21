using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource wallAudioSource;
    public AudioSource paletteAudioSource;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("WallCollisionSound"))
        {
            wallAudioSource.Play();
        }
        
        if (collision.collider.gameObject.CompareTag("PaletteCollisionSound"))
        {
            paletteAudioSource.Play();
        }
    }
}
