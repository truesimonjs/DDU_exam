using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    private bool firstStart = true;
    public Transform waypointParent;
    //ref
    private Sight sight;
    private NavMeshAgent agent;
    private Transform player;
    //used vars
    public int currentWaypoint;
    public override void StateStart()
    {
        if (firstStart)
        {
        agent = GetComponent<NavMeshAgent>();
        currentWaypoint = 0;
            firstStart = false;
        }
        agent.SetDestination(waypointParent.GetChild(currentWaypoint).position);
    }

    public override void StateUpdate()
    {


        if (Vector3.Distance(transform.position, waypointParent.GetChild(currentWaypoint).position) < agent.stoppingDistance)
        {
            currentWaypoint += 1;
            if (currentWaypoint > waypointParent.childCount - 1) currentWaypoint = 0;
            agent.SetDestination(waypointParent.GetChild(currentWaypoint).position);

        }
    }
    public void glance()
    {
        List<Transform> detected = sight.activate();
        if (detected.Count > 0)
        {
          


            float Seestarget = player == detected[0] ? 1 : -1;
            glanceMeter += 0.1f * Seestarget * Time.deltaTime;
            if (glanceMeter >= 1)
            {
                glanceMeter = 0;
               
            }
        }

    }
}
