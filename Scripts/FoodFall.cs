using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFall : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool left = false, right = false, heat = false;
    private int taste = 0;
    [SerializeField] private int normalTaste;
    [SerializeField] private Sprite[] state;
    private SpriteRenderer s_rend;
    void Start()
    {
        //s_rend = GetComponent<SpriteRenderer>();
        //s_rend.sprite = state[taste];
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (left)
        {
            left = false;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(1, 0.8f) * 10, ForceMode2D.Impulse);
        }
        if (right)
        {
            right = false;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(-1, 0.8f) * 10, ForceMode2D.Impulse);
        }
        if (heat)
        {
            //OnHeatFly();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "left")
        {
            left = true;
        }
        if (collision.tag == "right")
        {
            right = true;
        }
        if (collision.tag == "heat")
        {
            heat = true;
        }
    }

    private void OnHeatFly()
    {
        taste++;
        s_rend.sprite = state[taste];
    }
}
