using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFall : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool left = false, right = false, heat = false;
    [SerializeField] private int taste = -1;
    [SerializeField] private int normalTaste;
    [SerializeField] private Sprite[] state;
    private SpriteRenderer s_rend;
    FatMan man;
    void Start()
    {
        s_rend = GetComponent<SpriteRenderer>();//пока влада не нарисует
        //s_rend.sprite = state[taste];//пока влада не дорисует
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (left)
        {
            if (man.eat == true)
            {
                Swallow();
            }
            left = false;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(1, 0.8f) * 10, ForceMode2D.Impulse);
        }
        if (right)
        {
            if (man.eat == true)
            {
                Swallow();
            }
            right = false;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(-1, 0.8f) * 10, ForceMode2D.Impulse);
        }
        if (heat)
        {
            heat = false;
            OnHeatFly();//пока влада не нарисует
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "left")
        {
            man = collision.gameObject.GetComponent<FatMan>();
            left = true;
        }
        if (collision.tag == "right")
        {
            man = collision.gameObject.GetComponent<FatMan>();
            right = true;
        }
        if (collision.tag == "heat")
        {
            heat = true;
        }
    }

    private void OnHeatFly()
    {
        if (taste + 2 <= state.Length)
        {
            taste++;
            s_rend.sprite = state[taste];
        }
    }

    private void Swallow()
    {
        Destroy(gameObject);
    }
}
