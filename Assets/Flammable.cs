using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : MonoBehaviour
{
    public bool burning;
    public GameObject FireEffect;

    CubeScript cubeScript;
    Ruble ruble;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag != "Rubble")
        {
            cubeScript = GetComponent<CubeScript>();
        }
        else
        {
            ruble = GetComponent<Ruble>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (burning)
        {
            if (gameObject.tag != "Rubble")
            {
                cubeScript.hp -= Time.deltaTime;
            }
            else
            {
                ruble.hp -= Time.deltaTime;
            }
            FireEffect.SetActive(true);

            RaycastHit2D[] boxCast = Physics2D.BoxCastAll(transform.position, new Vector2(1.5f, 1.5f), 0f, Vector2.zero);
            for (int i = 0; i < boxCast.Length; i++)
            {
                if (boxCast[i].collider.tag == "WoodCube" || boxCast[i].collider.tag == "Rubble" || boxCast[i].collider.tag == "WoodPlank")
                {
                    if (Random.Range(1, 150) == 1)
                    {
                        boxCast[i].collider.GetComponent<Flammable>().burning = true;
                    }
                }
            }
        }

        FireEffect.transform.rotation = Quaternion.LookRotation(Vector2.up, Vector2.up);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            if (Random.Range(1, 5) == 2)
            {
                if (gameObject.tag != "Rubble")
                {
                    cubeScript.hp--;
                }
                else
                {
                    ruble.hp--;
                }
                burning = true;
                
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (burning && collision.gameObject.tag == "WoodCube")
        {
            if (Random.Range(1, 5) == 1)
            {
                //collision.GetComponent<Flammable>().burning = true;
            }
        }
    }
}
