using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{

    public GameObject woodCubePrefab;
    public GameObject gridOverlayPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCube()
    {
        Instantiate(woodCubePrefab, transform.position, Quaternion.identity);
    }
}
