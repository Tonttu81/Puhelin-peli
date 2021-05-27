using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerScript : MonoBehaviour
{
    public float fireSpeed;

    float timer = 0.05f;

    bool choosingAngle;

    GridScript gridScript;

    public GameObject rotationPoint;
    public GameObject bulletSpawner;
    public GameObject firePrefab;

    // Start is called before the first frame update
    void Start()
    {
        gridScript = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridScript>();
        gridScript.rotating = true;
        choosingAngle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (choosingAngle)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                Vector3 dir = touchPos - transform.position;
                float rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                rotationPoint.transform.rotation = Quaternion.Euler(0f, 0f, rotation);
            }
            else
            {
                choosingAngle = false;
                gridScript.rotating = false;
            }
        }

        if (gridScript.playing)
        {
            timer -= 1 * Time.deltaTime;
            if (timer < 0)
            {
                timer = 0.05f;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject fire = Instantiate(firePrefab, bulletSpawner.transform.position, Quaternion.identity);

        float randomY = Random.Range(-0.1f, 0.1f);

        fire.GetComponent<Rigidbody2D>().AddForce((bulletSpawner.transform.right + new Vector3(0, randomY)) * fireSpeed, ForceMode2D.Impulse);
    }
}
