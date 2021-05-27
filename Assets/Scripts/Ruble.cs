using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruble : MonoBehaviour
{

    public BoxCollider2D CL;
    public Rigidbody2D RB;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Circle")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Stonecube")
        {
            Destroy(gameObject);
        }
    }
}
