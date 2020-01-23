using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XGravitySwap : MonoBehaviour
{
    
    private Rigidbody2D rb;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) // button for switch gravity to Up
        {
            Physics2D.gravity = new Vector2(0f, 9.81f);
        }
        
        else if(Input.GetKeyDown(KeyCode.S)) // button for switch gravity to Down
        {
            Physics2D.gravity = new Vector2(0f, -9.81f);
        }
        
        else if(Input.GetKeyDown(KeyCode.A)) // button for switch gravity to Left
        {
            Physics2D.gravity = new Vector2(-200.81f, 0f);
        }
        
        else if(Input.GetKeyDown(KeyCode.D)) // button for switch gravity to Right
        {
            Physics2D.gravity = new Vector2(200.81f, 0f);
        }
    }
}
