using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;         // The health of the enemy
    public int scoreValue = 10;         // The score value of the enemy when destroyed
    public GameObject deathEffect;      // The particle effect that plays when the enemy is destroyed

    private Transform target;           // The target of the enemy

    // Takes damage and destroys the enemy when its health reaches zero
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    // Destroys the enemy and plays the death particle effect
    void Die()
    {
        PlayerStats.Money += scoreValue;
        Destroy(gameObject);
    }
}
