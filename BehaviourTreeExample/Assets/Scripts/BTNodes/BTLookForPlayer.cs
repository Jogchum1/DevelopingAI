using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTLookForPlayer : BTBaseNode
{
    private Transform target;
    private Transform guard;
    private float viewAngle;

    public BTLookForPlayer(Transform _target, Transform _guard, float _viewAngle)
    {
        target = _target;
        guard = _guard;
        viewAngle = _viewAngle;
    }

    public override BTResult Run()
    {
        Vector3 dirToTarget = (target.position - guard.position).normalized;
        if(Vector3.Angle(guard.forward, dirToTarget) < viewAngle / 2)
        {
            Debug.Log("ER IS IETS IN JE VIEWANGLE OFZO");
            //raycast
            return BTResult.Success;
        }
        else
        {
            Debug.Log("NIETS");
            return BTResult.Running;
        }
    }
}
