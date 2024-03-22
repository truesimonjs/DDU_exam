using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public Transform waypointParent;
    //public Transform[] waypoints;
    private NavMeshAgent agent;
    public int currentTarget;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTarget = 0;
        agent.SetDestination(waypointParent.GetChild(currentTarget).position);
        
    }
    private void Update()
    {
        //Debug.Log(waypoints[currentTarget].name);
        Debug.Log(currentTarget);
        if (Vector3.Distance(transform.position, waypointParent.GetChild(currentTarget).position) < agent.stoppingDistance)
        {
            currentTarget += 1;
            if (currentTarget > waypointParent.childCount - 1) currentTarget = 0;
            agent.SetDestination(waypointParent.GetChild(currentTarget).position);
        }
    }


    

}
