using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingEnemy : Enemy
{
    public int health = 80;
    public bool isDie;
    public GameObject deathEffect;
    public GameObject ef;
    public bool faceright = true;
    public float speedEnemy;
    public bool turn;
    public bool canTurn = true;
    public BoxCollider2D col1;
    public BoxCollider2D col2;
    public void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speedEnemy, 0);
    }
    public IEnumerator wait()
    {
        canTurn = false;
        yield return new WaitForSeconds(0.2f);
        canTurn = true;
    }
    public void flip()
    {
        faceright = !faceright;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.transform.tag == "Wall")
        {
            StartCoroutine("wait");
            flip();
            speedEnemy *= -1;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        ef = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(ef, 0.35f);
        Destroy(this.gameObject);
        isDie = true;
    }
}
