using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public float hp;

    public float explosionForce;

    GridScript gridScript;

    CubeSelector cubeSelector;

    GameObject currentCube;

    public Rigidbody2D rb2D;

    public LayerMask cubeMask;

    public GameObject brokenCube;

    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        gridScript = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridScript>();
        cubeSelector = GameObject.FindGameObjectWithTag("CubeSelector").GetComponent<CubeSelector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != "OverlayCube")
        {
            if (gridScript.playing)
            {
                rb2D.isKinematic = false;
            }
            else
            {
                rb2D.isKinematic = true;
            }
        }

        if (hp <= 0)
        {
            switch (gameObject.tag)
            {
                case "WoodCube":
                    Instantiate(brokenCube, transform.position, transform.rotation);
                    Destroy(gameObject);
                    break;
                case "StoneCube":
                    Instantiate(brokenCube, transform.position, transform.rotation);
                    Destroy(gameObject);
                    break;
                case "TntCube":
                    Explode();
                    Instantiate(Explosion, transform.position, transform.rotation);
                    Destroy(gameObject);
                    break;
            }
        }
    }
    public void SpawnCube()
    {
        Instantiate(cubeSelector.currentCube, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 vel;
        if (collision.tag != "Ground")
        {
            vel = collision.GetComponent<Rigidbody2D>().velocity;
        }
        else
        {
            vel = new Vector2(0f, 0f);
        }

        if (vel.x == 0 && vel.y == 0)
        {
            vel = rb2D.velocity;
        }

        float x;
        float y;

        if (vel.x < 0)
        {
            x = -vel.x;
        }
        else
        {
            x = vel.x;
        }
        if (vel.y < 0)
        {
            y = -vel.y;
        }
        else
        {
            y = vel.y;
        }


        hp -= (x + y) / 2;
    }

    void Explode()
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 10f, Vector2.zero, 0f, cubeMask);
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider != null)
            {
                Vector2 dir = (hit[i].collider.transform.position - transform.position);
                hit[i].collider.GetComponent<Rigidbody2D>().AddForce(dir * explosionForce, ForceMode2D.Impulse);
            }
        }
    }
}
