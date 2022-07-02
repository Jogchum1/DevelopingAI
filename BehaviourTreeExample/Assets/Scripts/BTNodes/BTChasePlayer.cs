using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BTChasePlayer : BTBaseNode
{
    public Transform target;
    private NavMeshAgent agent;
    private Blackboard bb;
    private string targetName;
    private float maxDistance;
    private float stoppingDistance;

    public BTChasePlayer(Blackboard _bb, NavMeshAgent _agent, string _target, float _maxDistance, float _stoppingDistance)
    {
        bb = _bb;
        agent = _agent;
        targetName = _target;
        maxDistance = _maxDistance;
        stoppingDistance = _stoppingDistance;
    }
    public override BTResult Run()
    {
        target = bb.GetValue<Transform>(targetName);
        agent.SetDestination(target.position);
        

        if (agent.pathStatus == NavMeshPathStatus.PathInvalid)
        {
            Debug.Log("Move Towards has failed due to invalid path");
            return BTResult.Failed;
        }

        if (Vector3.Distance(agent.transform.position, target.position) > maxDistance)
        {

            return BTResult.Failed;
        }
        else if (Vector3.Distance(agent.transform.position, target.position) <= stoppingDistance)
        {
            
            return BTResult.Success;

        }
        else
        {

            return BTResult.Running;
        }

        

        //return BTResult.Success;
    }

    
}
