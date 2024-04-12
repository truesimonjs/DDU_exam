using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    public float glanceDecay = 1;
    public Transform waypointParent;
    public GameObject senses;
    //ref
    public Sight[] sights;
    private NavMeshAgent agent;
    private Transform player;
    private EnemyScript owner;
    //used vars
    public int currentWaypoint = 0;
    public float glanceMeter;
    private void Awake()
    {
        owner = GetComponent<EnemyScript>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sights = senses.GetComponents<Sight>();
    }
    public override void StateStart(Transform target = null)
    {


        if (target != null)
        {
            waypointParent = target;
            currentWaypoint = 0;
        }
        agent.SetDestination(waypointParent.GetChild(currentWaypoint).position);
    }

    public override void StateUpdate()
    {

        glance();
        if (Vector3.Distance(transform.position, waypointParent.GetChild(currentWaypoint).position) < agent.stoppingDistance)
        {
            currentWaypoint += 1;
            if (currentWaypoint > waypointParent.childCount - 1) currentWaypoint = 0;
            agent.SetDestination(waypointParent.GetChild(currentWaypoint).position);

        }
    }
    public void glance()
    {
        float glanceChange = 0;
        foreach (Sight sight in sights)
        {
        List<Transform> detected = sight.activate();
        float Seestarget =  detected.Count > 0 && player == detected[0] ? 1 : 0;
        glanceChange += sight.awareness * Seestarget * Time.deltaTime;

        }

        glanceMeter += glanceChange;
        if (glanceChange == 0) glanceMeter = -glanceDecay;
        if (glanceMeter < 0) glanceMeter = 0;
        if (glanceMeter >= 1)
        {
            owner.switchState(EnemyScript.StateEnum.investigating, player);
            glanceMeter = 0;

        }


    }
}
