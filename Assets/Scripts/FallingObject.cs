using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] float objectSpeedY = 5f;
     [SerializeField] float objectSpeedX = 5f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float ySpeed;
    float xSpeed;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        ySpeed = player.transform.localScale.y * objectSpeedY;
        xSpeed = player.transform.localScale.x * objectSpeedX;
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(-xSpeed, -ySpeed);
    }

    // void OnTriggerEnter2D(Collider2D other) 
    // {
    //     if(other.tag == "Enemies")
    //     {
    //         Destroy(other.gameObject);
    //     }
    //     Destroy(gameObject);
    // }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.TryGetComponent<Invulnerability>(out Invulnerability invulnerability))
        {
            invulnerability.DeathPlayer(); // Damage the opponent and get the TakeDamage function
        }
        Destroy(gameObject);    
    }
}
