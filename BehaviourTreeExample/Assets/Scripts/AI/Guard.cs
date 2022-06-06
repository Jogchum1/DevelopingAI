﻿using System.Collections;
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
    public float stoppingDistance = 2f;

    public Transform player;
    public Transform weapon;
    public float viewAngle = 100;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        blackBoard = GetComponent<Blackboard>();
        blackBoard.SetValue<Transform>("Target", waypointSystem.waypoints[0]);
        blackBoard.SetValue<Transform>("Player", player);
        blackBoard.SetValue<Transform>("Weapon", weapon);


        attackBehaviour = new BTSequence(
                new BTDebug("ATTACK"),
                new BTLookForPlayer(player, transform, viewAngle),
                new BTGoTo(blackBoard, agent, "Weapon", stoppingDistance),
                new BTGoTo(blackBoard, agent, "Player", stoppingDistance)

            );

        patrolBehaviour = new BTSequence(
            new BTDebug("PATROL"),
            new BTSelectWaypoint(blackBoard, waypointSystem, "waypointSystem"),
            new BTGoTo(blackBoard, agent, "Target", stoppingDistance)
            //new BTLookForPlayer(target, transform, viewAngle)
            );

        chooseBehaviour = new BTSelector(attackBehaviour, patrolBehaviour);



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
