﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadDino : MonoBehaviour {
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 jumpForce;
    public float maxVel = 5f;
    public float yjumpForce = 300f;
    private bool isJumping = false;
    private bool movingRight = true;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpForce = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        float v = Input.GetAxis("Horizontal"); //aactualizacion de velocidad horizontal;
        Vector2 vel = new Vector2(0, rb.velocity.y);
        v *= maxVel;
        vel.x = v;
        rb.velocity = vel;

        if (v != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if(Input.GetAxis("Jump") > 0.01f)
        {
            if (!isJumping)
            {
                if (rb.velocity.y == 0f)
                {
                    isJumping = true;
                    jumpForce.x = 0f;
                    jumpForce.y = yjumpForce;
                    rb.AddForce(jumpForce);

                }
            }
        }
        else
        {
            isJumping = false;
        }
        if (movingRight && v < 0)
        {
            movingRight = false;
            Flip();
        }else if (!movingRight && v > 0)
        {
            movingRight = true;
            Flip();
        }
	}

    private void Flip()
    {
        var s = transform.localScale;
        s.x = -1;
        transform.localScale = s;
    }
}
