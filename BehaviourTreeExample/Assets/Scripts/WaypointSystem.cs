using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    public Transform[] waypoints;
    public int waypointCount = -1;

    // Start is called before the first frame update
    void Start()
    {
        //waypointIndex = 0;
    }

    public Transform NextWaypoint()
    {
        waypointCount++;
        if (waypointCount >= waypoints.Length)
        {
            waypointCount = 0;
        }
        return waypoints[waypointCount];
    }

    
}
