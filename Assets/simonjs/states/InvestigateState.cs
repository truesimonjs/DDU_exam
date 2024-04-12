using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class InvestigateState : State
{
    //ref
    private NavMeshAgent agent;
    private EnemyScript owner;
    private Transform player;
    //inspector values
    public Sight[] sights;
    public float investigationTime;
    public float TimePerSpot;
    private float glanceDecay;
    //used vars
    private Vector3 point;
    public float nextMovement;
    private float timeSpent;
    public float glanceMeter;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        owner = GetComponent<EnemyScript>();
    }
    public override void StateStart(Transform target = null)
    {
        point = target == null ? transform.position : target.position;
        timeSpent = 0;
        
        timeSpent = TimePerSpot;
        nextMovement = 0;
    }
    public override void StateUpdate()
    {
        glance();
        if (Time.time > nextMovement)
        {

            if (timeSpent >= investigationTime) owner.switchState(EnemyScript.StateEnum.patrolling, null, true);
            nextMovement = Time.time + TimePerSpot;
            timeSpent += TimePerSpot;
            agent.SetDestination(point + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)));

        }

    }
    public void glance()
    {
        float glanceChange = 0;
        foreach (Sight sight in sights)
        {
            List<Transform> detected = sight.activate();
            float Seestarget = detected.Count > 0 && player == detected[0] ? 1 : 0;
            glanceChange += sight.awareness * Seestarget * Time.deltaTime;

        }

        glanceMeter += glanceChange;
        if (glanceChange == 0) glanceMeter = -glanceDecay;
        if (glanceMeter < 0) glanceMeter = 0;
        if (glanceMeter >= 1)
        {
            owner.switchState(EnemyScript.StateEnum.chasing, player);
            glanceMeter = 0;

        }


    }


}
