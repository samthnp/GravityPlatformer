using System;
using UnityEngine;

public class Spike : MonoBehaviour
{


    void OnCollisionEnter(Collider2D col)
    {
        if (col.CompareTag("Spike"))
        {
            Destroy(col.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spike")
        {
            Destroy(col.gameObject);
        }
    }
}