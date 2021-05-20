using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public float bulletForce;

    float timer = 3;

    bool choosingAngle;

    GridScript gridScript;

    public GameObject rotationPoint;
    public GameObject bulletSpawner;
    public GameObject bulletPrefab;

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
                timer = 3;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(bulletSpawner.transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
