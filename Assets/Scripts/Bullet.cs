using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 15f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float xSpeed;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(xSpeed, 0f);
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

        if(collision.gameObject.TryGetComponent<EnemyMovement>(out EnemyMovement enemyComponent))
        {
            enemyComponent.TakeDamage(1); // Damage the opponent and get the TakeDamage function
        }
        if(collision.gameObject.TryGetComponent<Crates>(out Crates cratesComponent))
        {
            cratesComponent.TakeDamage(1); // Damage the opponent and get the TakeDamage function
        }

        Destroy(gameObject);    
    }
}
