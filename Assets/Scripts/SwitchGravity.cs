using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController player;

    private bool top;

    void Start()
    {
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.gravityScale *= -1;
            Rotation();
        }
    }

    void Rotation()
    {
        if(top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
            player.jumpForce = -1;
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
            player.jumpForce = 1;
            
        }

        player.facingRight = !player.facingRight;

        top = !top;
    }
}
