using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    GridScript gridScript;

    CubeSelector cubeSelector;

    GameObject currentCube;

    public Rigidbody2D rb2D;

    public GameObject brokenWoodCube;

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
    }
    public void SpawnCube()
    {
        Instantiate(cubeSelector.currentCube, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        {
            Instantiate(brokenWoodCube, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
