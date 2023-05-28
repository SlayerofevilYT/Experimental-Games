    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range;        // The range of the tower's attacks
    public float fireRate;     // The rate at which the tower fires
    public GameObject projectile;  // The projectile that the tower fires

    private Transform target;       // The current target of the tower
    private float fireCountdown = 0f;   // The time until the tower can fire again

    public AudioSource spawnAudio;

    public float distanceToEnemy;
    public float distanceToStoppedEnemy;

    private void Awake()
    {
        if (spawnAudio != null)
        {
            spawnAudio.Play();
        }
    }

    // Called when the script is first enabled
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Called every frame
    private void Update()
    {
        if (target == null)
        {
            return;
        }

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f;
        }

        fireCountdown -= Time.deltaTime;
    }

    // Finds the nearest enemy within range and sets it as the tower's target
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] stoppedEnemies = GameObject.FindGameObjectsWithTag("StoppedEnemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in stoppedEnemies)
        {
            distanceToStoppedEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToStoppedEnemy < shortestDistance)
            {
                shortestDistance = distanceToStoppedEnemy;
                nearestEnemy = enemy;
            }
        }

        foreach (GameObject enemy in enemies)
        {
            distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Fires a projectile at the tower's target
    private void Shoot()
    {
        GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        newProjectile.GetComponent<Projectile>().SetTarget(target);
    }

    // Draws a gizmo representing the tower's range in the Unity editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
