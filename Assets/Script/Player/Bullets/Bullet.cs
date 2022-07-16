using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    float speed;
    float damage;
    Vector2 dir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = dir * speed;
    }

    public void Shoot(Vector2 dir, float speed, int damage)
    {
        this.dir = dir;
        this.damage = damage;
        this.speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<EnemyScript>();

        if (enemy != null)
        {
            //  enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }


    }
}
