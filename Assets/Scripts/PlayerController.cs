using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float speed;
   public float jumpForce;
   private float moveInput;

   private Rigidbody2D rb;

   public bool facingRight = true;

   private bool isGrounded;
   public Transform groundCheck;
   public float checkRadius;
   public LayerMask whatIsGround;

   private int extraJump;
   public int extraJumpValue;
   
   private bool top;
   private PlayerController player;
   
   void Start()
   {
      extraJump = extraJumpValue;
      rb = GetComponent<Rigidbody2D>();
      player = GetComponent<PlayerController>();
   }

   private void FixedUpdate()
   {

      moveInput = Input.GetAxisRaw("Horizontal");
      rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

      if (facingRight == false && moveInput > 0)
      {
         Flip();
      }
      
      else if (facingRight == true && moveInput < 0)
      {
         Flip();
      }

      isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

   }

   void Update()
   {

      if (Input.GetKeyDown(KeyCode.UpArrow))
      {
         rb.gravityScale *= -1;
         Rotation();
         player.jumpForce = -1 * jumpForce;
      }

      if (rb.gravityScale >= 0)
      {
         restoreGravity();
      }
      
      if (isGrounded == true)
      {
         extraJump = extraJumpValue;
      }
      
      if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
      {
         rb.velocity = Vector2.up * jumpForce;
         extraJump--;
      }
      
      else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded == true)
      {
         rb.velocity = Vector2.up * jumpForce;
      }
   }

   void Flip()
   {
      facingRight = !facingRight;
      Vector3 Scaler = transform.localScale;
      Scaler.x *= -1;
      transform.localScale = Scaler;
   }
   
   void Rotation()
   {

      if(top == false)
      {
         transform.eulerAngles = new Vector3(0, 0, 180f);
      }
      else
      {
         transform.eulerAngles = Vector3.zero;
      }

      player.facingRight = !player.facingRight;

      top = !top;
   }
   
   void restoreGravity()
   {
      player.jumpForce = 1 * jumpForce;
   }

   void OnCollisionEnter2D(Collision2D col)
   {
      if (col.gameObject.tag == "Spike")
      {
         GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
         foreach(GameObject Player in Players)
            GameObject.Destroy(Player);
      }
         
   }
}
