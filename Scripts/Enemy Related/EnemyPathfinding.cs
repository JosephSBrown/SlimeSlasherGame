using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{

    public Transform player;
    public GameObject facing;
    private Rigidbody2D rb;
    private Vector2 movement;

    public float moveSpeed = 1f;
    public float fov;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        Vector3 scale = transform.localScale;
        if (facing.transform.position.x < transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
        }
        else 
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate()
    {
        if (player.position.x - transform.position.x < 15f && player.position.x - transform.position.x > -15f && player.position.y - transform.position.y < 15f && player.position.y - transform.position.y > -15f)
        {
            moveEnemy(movement);
        }
    }

    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

}
