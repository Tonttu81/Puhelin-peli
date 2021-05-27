using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Touch Zero = Input.GetTouch(0);
        Touch One = Input.GetTouch(1);

        Vector2 zeroPos = Camera.main.ScreenToWorldPoint(Zero.position);
        Vector2 onePos = Camera.main.ScreenToWorldPoint(One.position);

    }
}
