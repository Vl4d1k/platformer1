﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;
    public Text scoreText;
    public float movementSpeed;//speed

    float horizontalMovementSpeed;
    bool isJump = false;
    bool isHurt = false;

    int score;
    public BoxCollider2D boxCol;
    public CircleCollider2D circlrCol;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
        isJump = false;
        isHurt = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        horizontalMovementSpeed = Input.GetAxisRaw("Horizontal") * movementSpeed;
        anim.SetFloat("Speed", Mathf.Abs(horizontalMovementSpeed));
        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
            anim.SetBool("isJump" , true);
        }
    }
    public void onLanding()
    {
        isJump = false;
        anim.SetBool("isJump", false);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.transform.tag == "Gem")
        {
            Debug.LogError("gem", col);
            IncScore();
            Destroy(col.gameObject);
        }
        if (col.gameObject.transform.tag == "Enemy")
        {
                anim.SetBool("isHurt", true);
                boxCol.enabled = false;
                circlrCol.enabled = false;
        }
    }

    private void IncScore()
    {
        score++;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMovementSpeed * Time.fixedDeltaTime, false, isJump);
    }
}