using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using UnityEngine.UI;
public class Rogue : MonoBehaviour
{

    private BTBaseNode FollowBehaviour;
    private BTBaseNode SupportBehaviour;
    private BTBaseNode ChooseBehaviour;
    private NavMeshAgent agent;
    private Animator animator;
    private Blackboard blackBoard;
    public float stoppingDistance = 2f;

    public Blackboard publicBlackBoard;

    public GameObject player;
    public GameObject guard;
    public GameObject bomb;
    public Image imageHolder;
    public Sprite[] sprites;
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
            new BTChaneSprite(imageHolder, sprites[1]),
            new BTFindCover(blackBoard, agent, guard.transform, transform),
            new BTDoAnimation(animator, "Walk Crouch"),
            new BTGoToCover(blackBoard, agent, 2f),
            new BTDoAnimation(animator, "Crouch Idle"),
            new BTChaneSprite(imageHolder, sprites[2]),

            new BTThrowSmokeBomb(blackBoard, bomb, guard.transform, player.transform),

            new BTWait(2f)
          
            
           );

        FollowBehaviour = new BTSequence(
            new BTDoAnimation(animator, "Walk Crouch"),
            new BTChaneSprite(imageHolder, sprites[0]),
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
