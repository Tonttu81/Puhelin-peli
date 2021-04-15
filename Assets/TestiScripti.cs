using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestiScripti : MonoBehaviour
{
    public float throwSpeed;

    bool grabbing;

    Vector3 touchPos;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 z = Camera.main.ScreenToWorldPoint(touch.position);
            Vector3 touchPos = new Vector3(z.x, z.y, 0f);


            RaycastHit2D hit = Physics2D.Raycast(touchPos, new Vector2(0f, 0f), 1f);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Circle")
                {
                    print("toimii");
                    grabbing = true;
                }
            }
        }
        else
        {
            grabbing = false;
        }

        if (grabbing)
        {
            Vector3 direction = (touchPos - transform.position).normalized;

            transform.position += direction * throwSpeed * Time.deltaTime;
        }
    }
}
