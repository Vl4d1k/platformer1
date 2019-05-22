using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opposum : movingEnemy
{
    public void Attack()
    {
        if (health == 40)
        {
            StartCoroutine("wait");
            flip();
            speedEnemy *= -4;
        }
    }
}