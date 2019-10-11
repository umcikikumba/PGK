﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float Speed;
    public float JumpHeight;
    private Rigidbody2D _rigidbody2D;
    private bool faceRight;
    private bool onGround;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        faceRight = true;
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Move(horizontal);
        Flip(horizontal);
        if (Input.GetKeyDown("space") && onGround) Jump();
    }

    void Move(float horizontal)
    {
       //transform.Translate()
         _rigidbody2D.velocity = new Vector2(horizontal * Speed,_rigidbody2D.velocity.y);
    }
    void Flip(float horizontal)
    {
        if (horizontal > 0 && !faceRight || horizontal < 0 && faceRight)
        {
            faceRight = !faceRight;
            Vector3 flip = gameObject.transform.localScale;
            flip.x *= -1;
            transform.localScale = flip;
        }
    }
    void Jump()
    {
        onGround = false;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }
}