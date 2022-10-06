using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    public float moveSpeed;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized;

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (movement.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = false;
        }

    }

    void FixedUpdate()
    {

        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

    }
}
