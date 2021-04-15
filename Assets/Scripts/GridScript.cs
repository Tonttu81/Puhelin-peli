using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public bool erasing = false;

    int lapX = 0;
    int lapY = 0;

    public int gridWidth;


    public LayerMask cubeLayer;

    public GameObject gridCubePrefab;

    public Vector3[] gridCubePositions;

    // Start is called before the first frame update
    void Start()
    {   
        for (int i = 0; i < gridCubePositions.Length; i++)
        {
            if (lapX % gridWidth == 0)
            {
                lapX = 0;
                lapY--;
            }

            gridCubePositions[i].x = lapX;
            gridCubePositions[i].y = lapY;

            GameObject cube = Instantiate(gridCubePrefab, gridCubePositions[i], Quaternion.identity, transform);
            cube.transform.localPosition = gridCubePositions[i];

            lapX++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            RaycastHit2D hit = Physics2D.Raycast(touchPos, new Vector2(0f, 0f), 0f, cubeLayer);
            if (hit.collider != null)
            {
                if (erasing)
                {
                    if (hit.collider.tag == "WoodCube")
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
                else
                {
                    if (hit.collider.tag == "OverlayCube")
                    {
                        hit.collider.GetComponent<CubeScript>().ChangeCube();
                    }
                }
            }
        }
    }
}
