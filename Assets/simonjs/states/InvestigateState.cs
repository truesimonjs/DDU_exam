using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InvestigateState: MonoBehaviour
{
    public bool firstStart = true;
    private NavMeshAgent agent;
    private Vector3 point;
    public float nextMovement;
    private float timeSpent;
    //inspector values
    public float investigationTime;
    public float TimePerSpot;
    public void StateStart(Vector3 area)
    {
        timeSpent = 0;
        if (firstStart)
        {
            agent = GetComponent<NavMeshAgent>();
            firstStart = false;
        }
        point = area;
        agent.SetDestination(point);
        timeSpent = TimePerSpot;
        nextMovement = Time.time + TimePerSpot;
    }
    public bool StateUpdate()
    {

        if (Time.time > nextMovement)
        {
            if (timeSpent >= investigationTime) return true;
            Debug.Log(new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3)));
            nextMovement = Time.time + TimePerSpot;
            timeSpent += TimePerSpot;
            agent.SetDestination(point + new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3)));

        }
        return false;
    }
    

}
