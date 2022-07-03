using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
    public Image imageHolder;
    public Sprite[] sprites;
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
                new BTChaneSprite(imageHolder, sprites[1]),
                new BTLookForPlayer(player.transform, transform, viewAngle),

                    new BTCheckBool(blackBoard,
                        new BTChaneSprite(imageHolder, sprites[2]),
                        new BTGoTo(blackBoard, agent, "Weapon", 1f),
                        new BTPickUp(blackBoard, weapon, gameObject)),
                new BTChaneSprite(imageHolder, sprites[2]),
                new BTGoTo(blackBoard, agent, "Player", 10),
                new BTChasePlayer(blackBoard, agent, "Player", 20f, 2f),
                new BTChaneSprite(imageHolder, sprites[3]),
                new BTDoAnimation(animator, "Kick"),
                new BTAttack(player, gameObject, 1),
                new BTWait(1f)



            );

        patrolBehaviour = new BTSequence(

             new BTChaneSprite(imageHolder, sprites[0]),

             new BTSelector(
                new BTSelectWaypoint(blackBoard, waypointSystem, "waypointSystem"),

                new BTInvertResult(new BTLookForPlayer(player.transform, transform, viewAngle))),


            new BTInvertResult(new BTLookForPlayer(player.transform, transform, viewAngle)),
            new BTGoTo(blackBoard, agent, "Target", stoppingDistance)
                                
            
            );

        chooseBehaviour = new BTSelector(attackBehaviour, patrolBehaviour);

    }

    private void FixedUpdate()
    {
        chooseBehaviour?.Run();
    }

    
}
