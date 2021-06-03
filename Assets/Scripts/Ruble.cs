using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruble : MonoBehaviour
{
    public float hp;

    public BoxCollider2D CL;
    public Rigidbody2D RB;

    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Circle")
        {
            Destroy(gameObject);
        }
    }
}
