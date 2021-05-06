using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExplosion : MonoBehaviour
{
    public float explosionForce;

    GameObject[] buttonParts;

    // Start is called before the first frame update
    void Start()
    {
        buttonParts = GameObject.FindGameObjectsWithTag("ButtonPart");
        for (int i = 0; i < buttonParts.Length; i++)
        {
            Vector2 dir = buttonParts[i].transform.position - transform.position;
            buttonParts[i].GetComponent<Rigidbody2D>().AddForce(dir * explosionForce, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
