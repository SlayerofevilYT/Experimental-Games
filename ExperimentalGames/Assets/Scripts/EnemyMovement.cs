using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public Transform[] waypoints;
    private int waypointIndex;

    public void SetPath(Transform[] newWaypoints, int wpIndex)
    {
        waypoints = newWaypoints;
        waypointIndex = wpIndex;
        transform.position = waypoints[waypointIndex].position;
    }

    private void Update()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            return;
        }

        Vector3 targetPosition = waypoints[waypointIndex].position;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        if (distanceToTarget <= speed * Time.deltaTime)
        {
            // Reached the target waypoint
            transform.position = targetPosition;

            waypointIndex++;

            if (waypointIndex >= waypoints.Length)
            {
                PlayerStats.Lives--;
                Destroy(gameObject);
                return;
            }

            targetPosition = waypoints[waypointIndex].position;
            moveDirection = (targetPosition - transform.position).normalized;
        }

        // Check for obstacles in the way
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, 3.5f);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "StoppedEnemy")
            {
                return;
            } else if (hit.collider.tag == "PathTower")
            {
                gameObject.tag = "StoppedEnemy";
                // An obstacle is detected, stop moving
                return;
            }
        }

        // Move towards the target waypoint
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}

