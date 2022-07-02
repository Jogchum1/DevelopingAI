using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class Rogue : MonoBehaviour
{

    private BTBaseNode FollowBehaviour;
    private BTBaseNode SupportBehaviour;
    private BTBaseNode ChooseBehaviour;
    private NavMeshAgent agent;
    private Animator animator;
    private Blackboard blackBoard;
    public float stoppingDistance = 2f;
    private string cover;

    public GameObject player;
    public GameObject guard;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        blackBoard = new Blackboard();
        blackBoard.SetValue<Transform>("Player", player.transform);
        blackBoard.SetValue<Transform>("Guard", guard.transform);
        SupportBehaviour = new BTSequence(
            
            new BTCheckPlayer(player),
            new BTDebug("HELP DE SPELER"),
            new BTFindCover(blackBoard, agent, guard.transform, transform),
            new BTGoToCover(blackBoard, agent, 0.2f)
          
            
           );

        FollowBehaviour = new BTSequence(
            new BTDoAnimation(animator, "Walk Crouch"),
            new BTGoTo(blackBoard, agent, "Player", stoppingDistance),
            new BTDoAnimation(animator, "Crouch Idle")
            
            );
        

        ChooseBehaviour = new BTSelector(SupportBehaviour, FollowBehaviour);
    }

    private void FixedUpdate()
    {
        ChooseBehaviour?.Run();
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
