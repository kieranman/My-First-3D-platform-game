using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;

    //speed of platform
    [SerializeField] float speed = 3f;
    void Update()
    {

        //if platform touches waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex++;
            // if it reaches end of array then reset it back to 0
            if (currentWaypointIndex >= waypoints.Length) {
                currentWaypointIndex = 0;
            }
        }

        // calculates new position between two game objects
        transform.position = Vector3.MoveTowards(
            transform.position,
            waypoints[currentWaypointIndex].transform.position,
            speed* Time.deltaTime);

    }
}
