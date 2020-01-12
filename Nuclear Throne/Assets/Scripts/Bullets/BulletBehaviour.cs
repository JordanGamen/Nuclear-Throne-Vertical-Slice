﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

    [SerializeField] private Bullet bullet;
    public Bullet BulletFired { get { return bullet; } set { bullet = value; } }

    public bool Loaded { get; set; }
    public bool PlayerControl { get; set; }

    public Weapon WeaponThatShot { get; set; }

    private int hits = 0;

    // Start is called before the first frame update
    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        if (bullet.fireType != Bullet.type.NORMAL)
        {
            Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
            GetComponent<BoxCollider2D>().size = S;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Loaded)
        {
            rb.velocity = transform.TransformVector(Vector3.up * speed);
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hits = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (bullet.Hits > hits)
        {
            if (PlayerControl && collision.CompareTag("Enemy") && !collision.GetComponent<EnemyAi>().Dead)
            {
                collision.GetComponent<EnemyAi>().Hit(WeaponThatShot.Damage, rb.velocity);
                hits++;
            }
            else if (!PlayerControl && collision.CompareTag("Player"))
            {
                collision.GetComponent<Player>().Hit(WeaponThatShot.Damage, rb.velocity, true);
                hits++;
            }
            else
            {
                if (!collision.CompareTag("Bullet") && !collision.CompareTag("Player") && !collision.CompareTag("Enemy"))
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            if (bullet.Dissapear)
            {
                Destroy(gameObject);
            }
        }
    }
}
