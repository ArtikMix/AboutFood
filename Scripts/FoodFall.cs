using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFall : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool left = false, right = false;
    void Start()
    {
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
            Debug.Log("right");
            right = false;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(-1, 0.8f) * 10, ForceMode2D.Impulse);
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
            right = false;
        }
    }
}
