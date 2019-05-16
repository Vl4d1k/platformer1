using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : Enemy
{
    public int health = 80;
    public GameObject deathEffect;
    public GameObject ef;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        ef = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(ef, 0.35f);
        isDie = true;
    }
}
