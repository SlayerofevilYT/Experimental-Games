using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;       // The speed of the projectile
    public float damage = 10f;      // The damage that the projectile deals

    private Transform target;       // The target of the projectile

    // Sets the target of the projectile
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    // Called every frame
    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    // Deals damage to the target and destroys the projectile
    private void HitTarget()
    {
        target.GetComponent<Enemy>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
