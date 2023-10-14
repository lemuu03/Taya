using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float health, maxHealth = 3f;
    public float knockbackForce;
    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, 0);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; // 3 -> 2 -> 1 -> 0 = Enemy Has Died

        if(health <= 0)
        {
            Destroy(gameObject);
            //Enemies to take damage
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Bullet")
        {
            Vector2 difference = (transform.position - other.transform.position).normalized;
            Vector2 force = difference * knockbackForce;
            myRigidbody.AddForce(force, ForceMode2D.Impulse); //if you don't want to take into consideration enemy's mass then use ForceMode.VelocityChange
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2 (-(Mathf.Sign(myRigidbody.velocity.x)), 1f); //what direction are you facing?
    }
}
