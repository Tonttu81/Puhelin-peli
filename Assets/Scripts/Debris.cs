using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    void Start()
    {
        GetComponent<ParticleSystem>().Pause();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
