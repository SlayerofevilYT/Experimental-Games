using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;         // The health of the enemy
    public int scoreValue = 10;         // The score value of the enemy when destroyed
    public GameObject deathEffect;      // The particle effect that plays when the enemy is destroyed

    private Transform target;           // The target of the enemy

    public Animator enemyAnim;

    public EnemyMovement movement;
    // Takes damage and destroys the enemy when its health reaches zero

    private IEnumerator DeathAnim()
    {
        if (enemyAnim != null)
        {
            enemyAnim.SetBool("isDead", true);
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            BeginDeath();
        }
    }

    // Destroys the enemy and plays the death particle effect
    void BeginDeath()
    {
        PlayerStats.Money += scoreValue;
        this.gameObject.tag = "Dead";
        movement.isAlive = false;
        StartCoroutine(DeathAnim());
    }
}
