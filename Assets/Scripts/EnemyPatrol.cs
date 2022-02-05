using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public bool mustPatrol;
    private bool mustFlip = false;

    [SerializeField]
    private Rigidbody2D enemy;

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private Transform groundCheckPosition;

    [SerializeField]
    private LayerMask groundLayer;



    void Start()
    {
        mustPatrol = true;
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer);
        }
    }


    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (mustFlip)
        {
            Flip();
        }
        enemy.velocity = new Vector2(walkSpeed * Time.deltaTime, enemy.velocity.y);
    }

    private void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("enemy"))
        //{
            //Flip();
        //}
    }
}
