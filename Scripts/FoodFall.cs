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
    FatMan man;
    Quaternion quaternion;
    ScoreManager score;
    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        s_rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        quaternion = Quaternion.Euler(0f, 0f, Random.Range(0, 360f));
        GameObject[] aCollisionObjects;
        aCollisionObjects = GameObject.FindGameObjectsWithTag("food");
        foreach(GameObject g in aCollisionObjects)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), g.GetComponent<Collider2D>());
        }
    }

    void Update()
    {
        GameObject[] aCollisionObjects;
        aCollisionObjects = GameObject.FindGameObjectsWithTag("food");
        foreach (GameObject g in aCollisionObjects)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), g.GetComponent<Collider2D>());
        }
        transform.rotation = Quaternion.Lerp(Quaternion.identity, quaternion, Mathf.PingPong(Time.time, 1f));
        if (left)
        {
            if (man.eat == true)
            {
                Swallow();
            }
            left = false;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(1, 0.6f) * 10, ForceMode2D.Impulse);
        }
        if (right)
        {
            if (man.eat == true)
            {
                Swallow();
            }
            right = false;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(-1, 0.6f) * 10, ForceMode2D.Impulse);
        }
        if (heat)
        {
            heat = false;
            OnHeatFly();//???? ????? ?? ????????
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
        taste++;
        if (taste-1 <= state.Length)
        {
            s_rend.sprite = state[taste];
        }
    }

    private void Swallow()
    {
        if (taste == normalTaste)
        {
            score.TopUp(10);
        }
        else
        {
            score.TopUp(-20);
        }
        Destroy(gameObject);
    }
}
