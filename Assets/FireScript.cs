using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public float scaleSpeed;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Fire") || !other.CompareTag("WoodPlank") ||!other.CompareTag("WoodCube") || !other.CompareTag("TntCube") || !other.CompareTag("Rubble"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;

        if (transform.localScale.x > 0.9)
        {
            Destroy(gameObject);
        }
    }
}
