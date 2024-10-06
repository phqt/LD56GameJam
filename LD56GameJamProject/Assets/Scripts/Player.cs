using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private bool isFacingRight = true;

    private Rigidbody2D rb;

    float horizontal;
    float y;

    bool jumping;

    public float maxYVelocity;

    private float fallDamageAmount = 50f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        y = rb.velocity.y;
        Flip();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * Time.deltaTime * moveSpeed, ForceMode2D.Impulse);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * Time.deltaTime * moveSpeed, ForceMode2D.Impulse);
        }

        if (jumping && rb.velocity.y == 0)
        {
            jumping = false;
        }

        if (maxYVelocity <= -40)
        {
            TakeFallDamage();
        }

        else if (jumping)
        {
            if (rb.velocity.y < maxYVelocity)
                maxYVelocity = rb.velocity.y;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            
            jumping = true;
            maxYVelocity = 0;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void TakeFallDamage()
    {
        GetComponent<PlayerHealth>().TakeDamage(fallDamageAmount);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
