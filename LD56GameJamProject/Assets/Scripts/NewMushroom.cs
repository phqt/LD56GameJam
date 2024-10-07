using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMushroom : MonoBehaviour
{
    public float bounceStrength = 20f;  
    public float bounceAngle = 45f;     
    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player collided with mushroom");
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                float angleInRadians = bounceAngle * Mathf.Deg2Rad;

                Vector2 bounceDirection = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));

                playerRb.velocity = bounceDirection * bounceStrength;
            }
        }
    }
}

