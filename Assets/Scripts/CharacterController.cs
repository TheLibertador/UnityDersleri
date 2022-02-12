using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    [SerializeField] private Animator _animator;

    private Rigidbody2D player;

    [SerializeField] private Text coinText;
    private int coin = 0;

    private bool onAir;
    [SerializeField] private GameObject WinText;

    private int _sceneIndex;
    private String _sceneName;
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        var activeScene = SceneManager.GetActiveScene();
        _sceneIndex = activeScene.buildIndex;
        _sceneName = activeScene.name;
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
        else if (other.gameObject.CompareTag("Tuzaklar"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coin++;
            Destroy(other.gameObject);
            coinText.text = coin.ToString();
        }
        else if (other.gameObject.CompareTag("LevelEnd"))
        {
            FirebaseAnalytics.LogEvent("level_passed", new Parameter("Scene_Name", _sceneName),
                new Parameter("Scene_Index", _sceneIndex));
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelStart);
            SceneManager.LoadScene(1);
        }
    }
}
