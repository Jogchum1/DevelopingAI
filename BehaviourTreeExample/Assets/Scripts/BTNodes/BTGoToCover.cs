using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTGoToCover : BTBaseNode
{
    private Blackboard bb;
    private NavMeshAgent agent;
    private float stoppingDistance;
    private Vector3 target;
    public BTGoToCover(Blackboard _bb, NavMeshAgent _agent, float _stoppingDistance)
    {
        bb = _bb;
        agent = _agent;
        stoppingDistance = _stoppingDistance;
    }

    public override BTResult Run()
    {
        target = bb.GetValue<Vector3>("Cover");
        agent.SetDestination(target);
        //Debug.Log(target.position);
        // Debug.Log("HEY");

        if (agent.pathStatus == NavMeshPathStatus.PathInvalid)
        {
            Debug.Log("Move Towards has failed due to invalid path");
            return BTResult.Failed;
        }

        if (Vector3.Distance(agent.transform.position, target) <= stoppingDistance)
        {

            return BTResult.Success;
        }
        else
        {
            return BTResult.Running;
        }
    }

  
    
}
