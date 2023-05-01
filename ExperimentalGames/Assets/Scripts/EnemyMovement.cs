using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public Transform[] waypoints;
    private int waypointIndex;

    public void SetPath(Transform[] newWaypoints)
    {
        waypoints = newWaypoints;
        waypointIndex = 0;
        transform.position = waypoints[waypointIndex].position;
    }

    private void Update()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            return;
        }

        Vector3 targetPosition = waypoints[waypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            waypointIndex++;

            if (waypointIndex >= waypoints.Length)
            {
                PlayerStats.Lives--;
                Destroy(gameObject);
            }
        }
    }
}
