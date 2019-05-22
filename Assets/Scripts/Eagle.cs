using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : movingEnemy
{
    public Transform firePoint;
    public GameObject bull;
    public GameObject bul;
    int time;
    private void Start()
    {
        time = 0;
    }
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speedEnemy, 0);
        time++;
        if (time > 250)
        {
            Attack();
            time = 0;
        }
    }
    public override void Attack()
    {
        Instantiate(bull, firePoint.position, firePoint.rotation);
    }
}