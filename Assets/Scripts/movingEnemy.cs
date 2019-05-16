using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingEnemy : Enemy
{
    public int health = 80;
    public GameObject deathEffect;
    public GameObject ef;
    private bool faceright = true;
    public float speedEnemy;
    private bool turn;
    private bool canTurn = true;
    public BoxCollider2D col1;
    public BoxCollider2D col2;

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speedEnemy, 0);
    }
    
    IEnumerator wait()
    {
        canTurn = false;
        yield return new WaitForSeconds(0.2f);
        canTurn = true;
    }
    void flip()
    {
        faceright = !faceright;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void OnTriggerEnter2D(Collider2D col)
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
    public void Die()
    {
        ef = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(ef, 0.35f);
        Destroy(this.gameObject);
        isDie = true;
    }
}
