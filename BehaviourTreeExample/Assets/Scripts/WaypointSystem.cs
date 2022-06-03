using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    public Transform[] waypoints;
    public int waypointIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        //waypointIndex = 0;
    }

    public Transform NextWaypoint()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        return waypoints[waypointIndex];
    }

    
}
