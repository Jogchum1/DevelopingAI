using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTGoTo : BTBaseNode
{
    public Transform target;
    private NavMeshAgent agent;
    private Blackboard bb;
    private string targetName;
    private float stoppingDistance;
    private Sprite sprite;

    public BTGoTo(Blackboard _bb, NavMeshAgent _agent, string _target, float _stoppingDistance)
    {
        bb = _bb;
        agent = _agent;
        targetName = _target;
        stoppingDistance = _stoppingDistance;
    }

    public void OnEnter()
    {
        //Debug.Log("HEY");
        
    }

    public override BTResult Run()
    {
        target = bb.GetValue<Transform>(targetName);
        agent.SetDestination(target.position);
        //Debug.Log(target.position);
        // Debug.Log("HEY");

        if (agent.pathStatus == NavMeshPathStatus.PathInvalid)
        {
            Debug.Log("Move Towards has failed due to invalid path");
            return BTResult.Failed;
        }

        if (Vector3.Distance(agent.transform.position, target.position) <= stoppingDistance)
        {

            return BTResult.Success;
        }
        else
        {
            return BTResult.Running;
        }
        return BTResult.Success;
    }

    
}
