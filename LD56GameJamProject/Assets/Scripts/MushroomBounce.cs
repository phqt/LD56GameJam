using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBounce : MonoBehaviour
{
    public float bounceStrength = 5f;
    public Rigidbody2D rb;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("player collided");
            rb.AddForce(Vector2.up * Time.deltaTime * bounceStrength, ForceMode2D.Impulse);
        }
    }
}
