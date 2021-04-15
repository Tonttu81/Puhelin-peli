using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    GridScript gridScript;

    public Rigidbody2D rb2D;

    public GameObject woodCubePrefab;
    public GameObject gridOverlayPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gridScript = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridScript>();
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

    public void ChangeCube()
    {
        Instantiate(woodCubePrefab, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity);
    }
}
