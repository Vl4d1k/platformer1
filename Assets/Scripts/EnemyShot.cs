using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
        public float bulSpeed = 2f;
        public Rigidbody2D rb;
        public GameObject impactEffect;
        public GameObject ef;
        public GameObject ch;
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.transform.tag == "Ground")
            {
                //Destroy(this.gameObject);
                ef = Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(ef, 0.35f);
            }
        }
}