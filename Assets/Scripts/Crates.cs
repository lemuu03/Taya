using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 2f;
    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        health = maxHealth;
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

}
