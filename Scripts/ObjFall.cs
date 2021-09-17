using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFall : MonoBehaviour
{
    private int destroying = 0;
    private Rigidbody2D rb;
    private bool left = false, right = false, heat = false;
    FatMan man;
    Quaternion quaternion;
    ScoreManager score;
    string type;
    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        rb = GetComponent<Rigidbody2D>();
        quaternion = Quaternion.Euler(0f, 0f, Random.Range(0, 360f));
        GameObject[] aCollisionObjects;
        aCollisionObjects = GameObject.FindGameObjectsWithTag("food");
        foreach (GameObject g in aCollisionObjects)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), g.GetComponent<Collider2D>());
        }
    }

    private void Update()
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
            DestroyingObj();
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

    public void DestroyingObj()
    {
        destroying++;
        if (destroying == 3)
        {
            Destroy(gameObject);
        }
    }

    private void Swallow()
    {
        score.TopUp(-50);
    }
}
