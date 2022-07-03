using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlowSmoke : MonoBehaviour
{
    public NavMeshAgent agent;


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Smoke")
        {
            agent.speed = 1f;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Smoke")
        {
            agent.speed = 3.5f;
        }
    }

}
