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
    public float stoppingDistance = 2f;

    public GameObject player;
    public GameObject weapon;
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
        blackBoard.SetValue<Transform>("Player", player.transform);
        blackBoard.SetValue<Transform>("Weapon", weapon.transform);

        blackBoard.SetValue<bool>("HasWeapon", false);

        attackBehaviour = new BTSequence(
                new BTDebug("AttackBehaviour"),
                new BTLookForPlayer(player.transform, transform, viewAngle),

                    new BTCheckBool(blackBoard,
                        new BTGoTo(blackBoard, agent, "Weapon", 1f),
                        new BTPickUp(blackBoard, weapon, gameObject)),

                new BTGoTo(blackBoard, agent, "Player", 10),
                new BTChasePlayer(blackBoard, agent, "Player", 20f, 2f),
                new BTDoAnimation(animator, "Kick"),
                new BTAttack(player, gameObject, 1),
                new BTWait(1f)



            );

        patrolBehaviour = new BTSequence(

            new BTDebug("PatrolBehaviour"),
            new BTSelectWaypoint(blackBoard, waypointSystem, "waypointSystem"),

            new BTSelector(new BTLookForPlayer(player.transform, transform, viewAngle),
                            new BTGoTo(blackBoard, agent, "Target", stoppingDistance))
                                
            
            );

        chooseBehaviour = new BTSelector(attackBehaviour, patrolBehaviour);

    }

    private void FixedUpdate()
    {
        chooseBehaviour?.Run();
    }

    
}
