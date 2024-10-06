using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool jumping;

    public float yVelocityMax;
    public float fallDamageAmount = 50f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (IsGrounded() && rb.velocity.y <= 0)
        {
            if (yVelocityMax < -40f)
            {
                GetComponent<PlayerHealth>().TakeDamage(fallDamageAmount);
            }

            yVelocityMax = 0f;
        }

        if (rb.velocity.y < yVelocityMax)
        {
            yVelocityMax = rb.velocity.y;
        }
    }

    private bool IsGrounded()
    {
        jumping = false;
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }


    public void resetVelocity()
    {
        yVelocityMax = 0f;
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