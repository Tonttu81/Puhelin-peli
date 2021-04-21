using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public Vector2 bulletTrajectory;

    float timer = 3;

    GridScript gridScript;

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gridScript = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridScript>();
    }

    // Update is called once per frame
    void Update()
    {
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
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(bulletTrajectory, ForceMode2D.Impulse);
    }
}
