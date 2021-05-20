using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanksSpriteChanger : MonoBehaviour
{
    public SpriteRenderer Lankut;

    public Sprite Lankku1;
    public Sprite Lankku2;
    public Sprite Lankku3;

    public bool Right;
    public bool Left;
    public bool Up;
    public bool Down;

    public string PlankTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlanksSpriteChanger planksSpriteChanger = collision.GetComponent<PlanksSpriteChanger>();
        if (planksSpriteChanger)
        {
            Vector2 Direction = AngleCheck(collision.transform);

            if (Down = true && Left != true && Right != true)
                Lankut.sprite = Lankku1;
            if (Left = true && Up != true && Down != true)
                Lankut.sprite = Lankku2;
            if (Right = true && Up != true && Down != true)
                Lankut.sprite = Lankku2;
            if (Up = true && Left != true && Right != true)
                Lankut.sprite = Lankku1;

            if (Up == true && Left == true && Right != true && Down != true)
                Lankut.sprite = Lankku3;
            if (Up == true && Right == true && Left != true && Down != true)
                Lankut.sprite = Lankku3;
            if (Down == true && Left == true && Right != true && Up != true)
                Lankut.sprite = Lankku3;
            if (Down == true && Right == true && Left != true && Up != true)
                Lankut.sprite = Lankku3;

            if (Down == true && Right == true && Left == true && Up == true)
                Lankut.sprite = Lankku3;
        }
    }
    Vector2 AngleCheck(Transform pos)
    {
        // lol se toimii
        Vector2 dir = pos.position - transform.position;
        if (dir == Vector2.down)
        {
            Down = true;
        }
        if (dir == Vector2.up)
        {
            Up = true;
        }
        if (dir == Vector2.left)
        {
            Left = true;
        }
        if (dir == Vector2.right)
        {
            Right = true;
        }
        return Vector2.zero;
    }
}
