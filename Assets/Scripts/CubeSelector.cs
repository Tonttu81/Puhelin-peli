using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSelector : MonoBehaviour
{
    GridScript gridScript;

    public GameObject currentCube;

    public GameObject woodCubePrefab;
    public GameObject stoneCubePrefab;
    public GameObject metalCubePrefab;

    // Start is called before the first frame update
    void Start()
    {
        gridScript = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridScript>();
        currentCube = woodCubePrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WoodCube()
    {
        currentCube = woodCubePrefab;
        gridScript.erasing = false;
    }

    public void StoneCube()
    {
        currentCube = stoneCubePrefab;
        gridScript.erasing = false;
    }

    public void MetalCube()
    {
        currentCube = metalCubePrefab;
        gridScript.erasing = false;
    }

    public void Eraser()
    {
        gridScript.erasing = true;
    }
}
