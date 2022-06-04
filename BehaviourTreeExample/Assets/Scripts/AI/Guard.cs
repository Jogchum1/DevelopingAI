using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    private BTBaseNode patrolBehaviour;
    private BTBaseNode attackBehaviour;
    private BTBaseNode chooseBehaviour;
    private NavMeshAgent agent;
    private Animator animator;
    private Blackboard blackBoard;
    public WaypointSystem waypointSystem;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        blackBoard = GetComponent<Blackboard>();
        blackBoard.SetValue<Transform>("Target", waypointSystem.waypoints[0]);

        patrolBehaviour = new BTSequence(
            new BTDebug("PATROL"),
            new BTFailed(),
            new BTDebug("PATROL2"),
            new BTSelectWaypoint(blackBoard, waypointSystem, "waypointSystem"),
            
            new BTGoTo(blackBoard, agent, "Target")

            );
        attackBehaviour = new BTSequence(
                new BTDebug("ATTACK"),
                new BTWait(2)
            );

        chooseBehaviour = new BTSelector(patrolBehaviour, attackBehaviour);



    }

    private void FixedUpdate()
    {
        chooseBehaviour?.Run();
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Handles.color = Color.yellow;
    //    Vector3 endPointLeft = viewTransform.position + (Quaternion.Euler(0, -ViewAngleInDegrees.Value, 0) * viewTransform.transform.forward).normalized * SightRange.Value;
    //    Vector3 endPointRight = viewTransform.position + (Quaternion.Euler(0, ViewAngleInDegrees.Value, 0) * viewTransform.transform.forward).normalized * SightRange.Value;

    //    Handles.DrawWireArc(viewTransform.position, Vector3.up, Quaternion.Euler(0, -ViewAngleInDegrees.Value, 0) * viewTransform.transform.forward, ViewAngleInDegrees.Value * 2, SightRange.Value);
    //    Gizmos.DrawLine(viewTransform.position, endPointLeft);
    //    Gizmos.DrawLine(viewTransform.position, endPointRight);

    //}
}
