using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    [SerializeField] private Animator _animator;

    private Rigidbody2D player;

    private bool onAir;
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Move();
        Jump();
    }


    private void Move()
    {
        float movement = Input.GetAxis("Horizontal");

        if (movement < 0)
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
            transform.localScale = new Vector3(-1, 1, 1);
            _animator.SetBool("isRunning",true);
        }
        else if(movement > 0)
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
            transform.localScale = new Vector3(1, 1, 1);
            _animator.SetBool("isRunning",true);
        }
        else
        {
            _animator.SetBool("isRunning",false);
        }
        
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && onAir == false)
        {
            player.AddForce(new Vector2(0f, 8f), ForceMode2D.Impulse);
            onAir = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onAir = false;
        }
    }
}
