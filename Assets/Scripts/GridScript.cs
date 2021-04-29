using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public bool erasing = false;

    public bool playing;

    int lapX = 0;
    int lapY = 0;

    public int gridWidth;

    public LayerMask cubeLayer;

    public GameObject gridCubePrefab;

    public Vector3[] gridCubePositions;

    CubeScript[] cubeScripts;
    public GameObject[] cubes;

    public GameObject woodCubePrefab;
    public GameObject stoneCubePrefab;
    public GameObject tntCubePrefab;

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
            gridCubePositions[i].z = 0;

            GameObject cube = Instantiate(gridCubePrefab, gridCubePositions[i], Quaternion.identity, transform);
            cube.transform.localPosition = gridCubePositions[i];

            lapX++;
        }

        cubeScripts = GetComponentsInChildren<CubeScript>();
        cubes = new GameObject[cubeScripts.Length];
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
                    if (hit.collider.tag != "OverlayCube")
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
                else
                {
                    if (hit.collider.tag == "OverlayCube")
                    {
                        hit.collider.GetComponent<CubeScript>().SpawnCube();
                    }
                    else
                    {
                        hit.collider.GetComponent<CubeScript>().SpawnCube();
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }

    public void Play()
    {
        for (int i = 0; i < cubeScripts.Length; i++)
        {
            print(cubeScripts[i].status.occupied);
            if (cubeScripts[i].status.occupied) // t�� 
            {
                cubes[i] = cubeScripts[i].gameObject;
            }
        }

        playing = true;
        gameObject.SetActive(false);
    }

    public void Reload()
    {
        CubeScript[] oldCubes = GameObject.FindObjectsOfType<CubeScript>();
        for (int i = 0; i < oldCubes.Length; i++)
        {
            Destroy(oldCubes[i].gameObject);
        }

        GameObject[] rubble = GameObject.FindGameObjectsWithTag("Rubble");
        for (int i = 0; i < rubble.Length; i++)
        {
            Destroy(rubble[i]);
        }

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Circle");
        for (int i = 0; i < projectiles.Length; i++)
        {
            Destroy(projectiles[i]);
        }

        playing = false;
        gameObject.SetActive(true);


        for (int i = 0; i < cubes.Length; i++)
        {
            if (cubes[i] != null)
            {
                switch (cubeScripts[i].status.cubeType)
                {
                    case "WoodCube":
                        Instantiate(woodCubePrefab, new Vector3(cubes[i].transform.position.x, cubes[i].transform.position.y, -1f), Quaternion.identity);
                        break;
                    case "StoneCube":
                        Instantiate(stoneCubePrefab, new Vector3(cubes[i].transform.position.x, cubes[i].transform.position.y, -1f), Quaternion.identity);
                        break;
                    case "TntCube":
                        Instantiate(tntCubePrefab, new Vector3(cubes[i].transform.position.x, cubes[i].transform.position.y, -1f), Quaternion.identity);
                        break;
                }
            }
        }
    }
}
