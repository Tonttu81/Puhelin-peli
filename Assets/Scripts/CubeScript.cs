using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Cube
{
    public string cubeType;
    public bool occupied;


    public Cube(string _cubeType, bool _occupied)
    {
        cubeType = _cubeType;
        occupied = _occupied;
    }
}

public class CubeScript : MonoBehaviour
{
    Vector3[] dirs = { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1) };
    //public string cubeType;
    //public bool occupied;

    public Cube status; // <<<

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
        else
        {
            RaycastHit2D gridCheck = Physics2D.Raycast(transform.position, new Vector3(0f, 0f, -2f), 20f);
            if (gridCheck.collider.gameObject != null)
            {
                if (gridCheck.collider.tag != "OverlayCube")
                {
                    //occupied = true;
                    //cubeType = gridCheck.collider.tag;

                    status = new Cube(gridCheck.collider.tag, true); 
                }
                else if (gridCheck.collider.tag == "OverlayCube")
                {
                    //occupied = false;
                    //cubeType = null;

                    status = new Cube("", false); 
                }
            }
        }

        if (!gridScript.playing)
        {
            if (gameObject.tag != "OverlayCube")
            {
                for (int i = 0; i < dirs.Length; i++)
                {
                    RaycastHit2D nextTo = Physics2D.Raycast(transform.position + dirs[i], dirs[i], 0.1f);
                    Debug.DrawRay(transform.position + dirs[i], dirs[i] * 0.1f, Color.red);
                    if (nextTo.collider)
                    {
                        if (nextTo.collider.tag != "OverlayCube")
                        {

                            // next time
                            //FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
                            //joint.connectedBody = nextTo.collider.GetComponent<Rigidbody2D>();
                        }
                    }
                }
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
        // Aika huonosti tehty mutta toimii kait lkdsalkjdlkj
        
        if (collision.tag != "OverlayCube")
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
                if (gameObject.tag != "OverlayCube")
                {
                    vel = rb2D.velocity;
                }
                
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
    }

    void Explode()
    {
        CameraShake.Instance.ShakeCamera(1, 0.5f);
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 10f, Vector2.zero, 0f, cubeMask);
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider != null)
            {
                if (hit[i].distance < 2)
                {
                    hit[i].collider.GetComponent<CubeScript>().hp -= 100;
                }
                Vector2 dir = (hit[i].collider.transform.position - transform.position);
                hit[i].collider.GetComponent<Rigidbody2D>().AddForce(dir * explosionForce, ForceMode2D.Impulse);
            }
        }
    }
}
