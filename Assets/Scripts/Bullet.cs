using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulSpeed = 20f;
    public Rigidbody2D rb;
    int damage = 20;
    public GameObject impactEffect;
    public GameObject ef;
    void Start()
    {
        rb.velocity = transform.right * bulSpeed;
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        StaticEnemy enemy1 = col.GetComponent<StaticEnemy>();
        movingEnemy enemy2 = col.GetComponent<movingEnemy>();
        if (enemy1 != null)
        {
            enemy1.TakeDamage(damage);
            ef = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(ef,0.35f);
        }
        if (enemy2 != null)
        {
            enemy2.TakeDamage(damage);
            ef = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(ef, 0.3f);
           
        }
    }
}
