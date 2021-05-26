using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSelector : MonoBehaviour
{
    GridScript gridScript;

    public GameObject currentCube;

    public GameObject woodCubePrefab;
    public GameObject stoneCubePrefab;
    public GameObject cannonPrefab;
    public GameObject TntCubePrefab;
    public GameObject PlanksPrefab;

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

    public void Planks()
    {
        currentCube = PlanksPrefab;
        gridScript.erasing = false;
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

    public void Cannon()
    {
        currentCube = cannonPrefab;
        gridScript.erasing = false;
    }

    public void TnTCube()
    {
        currentCube = TntCubePrefab;
        gridScript.erasing = false;
    }

    public void Eraser()
    {
        gridScript.erasing = true;
    }
}
