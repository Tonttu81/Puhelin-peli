using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{

    Camera cam;

    public GameObject ground1;
    public GameObject ground2;

    GameObject currentGround;
    GameObject otherGround;

    GameObject storage;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        currentGround = ground1;
        otherGround = ground2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenMax = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight));

        //en tii‰ miks t‰‰ toimii mutta se toimii joten ihansama
        if (currentGround.transform.position.x + currentGround.GetComponent<BoxCollider2D>().size.x >= screenMax.x - 5 && currentGround.transform.position.x + currentGround.GetComponent<BoxCollider2D>().size.x < screenMax.x)
        {
            otherGround.transform.position = new Vector3(currentGround.transform.position.x + currentGround.GetComponent<BoxCollider2D>().size.x + otherGround.GetComponent<BoxCollider2D>().size.x, currentGround.transform.position.y);
            storage = currentGround;
            currentGround = otherGround;
            otherGround = storage;
        }
    }
}
