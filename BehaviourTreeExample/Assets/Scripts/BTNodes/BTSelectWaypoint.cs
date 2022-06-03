using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSelectWaypoint : BTBaseNode
{
    private Blackboard bb;
    private string waypointSystemName;

    public BTSelectWaypoint(Blackboard blackboard, WaypointSystem waypointSystem, string _waypointSystemName)
    {
        bb = blackboard;
        waypointSystemName = _waypointSystemName;
        bb.SetValue<WaypointSystem>(waypointSystemName, waypointSystem);
    }

    public override BTResult Run()
    {
        Transform newWaypoint = bb.GetValue<WaypointSystem>(waypointSystemName).NextWaypoint();
        bb.SetValue<Transform>("Target", newWaypoint);
        return BTResult.Success;
    }
}
