using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : MonoBehaviour
{
    public bool burning;
    public GameObject FireEffect;

    CubeScript cubeScript;

    // Start is called before the first frame update
    void Start()
    {
        
        cubeScript = GetComponent<CubeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (burning)
        {
            cubeScript.hp -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            if (Random.Range(1, 5) == 2)
            {
                FireEffect.SetActive(true);
                burning = true;
                cubeScript.hp--;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (burning && collision.gameObject.tag == "WoodCube")
        {
            if (Random.Range(1, 5) == 1)
            {
                collision.GetComponent<Flammable>().burning = true;
            }
        }
    }
}
