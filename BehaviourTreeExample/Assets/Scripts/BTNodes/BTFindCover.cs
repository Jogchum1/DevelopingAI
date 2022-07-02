using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class BTFindCover : BTBaseNode
{
    private NavMeshAgent agent;
    private Blackboard bb;
    private Transform cover;
    private Transform enemy;
    private Transform rogue;
    public BTFindCover(Blackboard _bb, NavMeshAgent _agent, Transform _enemy, Transform _rogue)
    {
        agent = _agent;
        bb = _bb;
        enemy = _enemy;
        rogue = _rogue;
    }

    public override BTResult Run()
    {
        Debug.Log("FINDING TO COVER");

        List<NavMeshHit> hitList = new List<NavMeshHit>();
        NavMeshHit navHit;

        // Loop to create random points around the player so we can find the nearest point to all of them, storting the hits in a list
        for (int i = 0; i < 15; i++)
        {
            Vector3 spawnPoint = rogue.transform.position;
            Vector2 offset = Random.insideUnitCircle * i;
            spawnPoint.x += offset.x;
            spawnPoint.z += offset.y;

            NavMesh.FindClosestEdge(spawnPoint, out navHit, NavMesh.AllAreas);

            hitList.Add(navHit);
        }

        // sort the list by distance using Linq
        var sortedList = hitList.OrderBy(x => x.distance);

        // Write the list in console to check if it's sorted. (Spoiler: it is)
        foreach (NavMeshHit hit in sortedList)
        {
            Debug.Log(hit.distance);
        }

        // Loop through the sortedList and see if the hit normal doesn't point towards the enemy.
        // If it doesn't point towards the enemy, navigate the agent to that position and break the loop as this is the closest cover for the agent. (Because the list is sorted on distance)
        foreach (NavMeshHit hit in sortedList)
        {
            if (Vector3.Dot(hit.normal, (enemy.transform.position - rogue.transform.position)) < 0)
            {
                bb.SetValue<Vector3>("Cover", hit.position);
                Debug.Log(hit.position);
                return BTResult.Success;
                
            }
            else
            {
                return BTResult.Running;
            }
        }

        return BTResult.Failed;

    }
}

