using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDropper : MonoBehaviour
{
    public float cubeSpawnFrequency;

    [SerializeField ]float timer;

    public GameObject woodCubePrefab;
    public GameObject stoneCubePrefab;
    public GameObject tntCubePrefab;
    public GameObject NukePrefab;
    public GameObject SlimeBlockPreFab;

    Vector3 screenMin;
    Vector3 screenMax;

    GameObject randomCube;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        timer = cubeSpawnFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = cubeSpawnFrequency;

                screenMin = cam.ScreenToWorldPoint(new Vector3(0, 0));
                screenMax = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight));

                Vector3 randomPos = new Vector3(Random.Range(screenMin.x + 5, screenMax.x + 3), Random.Range(screenMax.y + 1, screenMax.y + 10));

                Quaternion randomRot = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));

                int rng2 = Random.Range(1, 50);
                if (rng2 == 7)
                {
                    GameObject Nuke = Instantiate(NukePrefab, randomPos, randomRot);
                    Nuke.GetComponent<Rigidbody2D>().isKinematic = false;
                }

                int rng = Random.Range(1, 10);
                
                if (rng == 6)
                {
                    randomCube = tntCubePrefab;
                }
                else if (rng <= 5)
                {
                    randomCube = woodCubePrefab;
                }
                else if (rng == 7)
                {
                    randomCube = SlimeBlockPreFab;
                }
                else
                {
                    randomCube = stoneCubePrefab;
                }

                GameObject spawnedCube = Instantiate(randomCube, randomPos, randomRot);
                spawnedCube.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }

        CubeScript[] cubes = GameObject.FindObjectsOfType<CubeScript>();
        for (int i = 0; i < cubes.Length; i++)
        {
            if (cubes[i].transform.position.x < screenMin.x - 2)
            {
                Destroy(cubes[i].gameObject);
            }
            
        }
        GameObject[] rubble = GameObject.FindGameObjectsWithTag("Rubble");
        for (int i = 0; i < rubble.Length; i++)
        {
            if (rubble[i].transform.position.x < screenMin.x - 2)
            {
                Destroy(rubble[i].gameObject);
            }
        }
    }
}
