using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    public float glanceDecay = 1;
    public GameObject senses;
    public Transform waypointParent;
    //ref
    private Sight[] sights;
    private NavMeshAgent agent;
    private Transform player;
    private EnemyScript owner;
    //used vars
    private int currentWaypoint = 0;
    private float glanceMeter;
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
        agent.speed = owner.walkSpeed;
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
        
        Glance.glance(ref glanceMeter, ref glanceDecay, sights);
        owner.healthBar.BarUpdate(glanceMeter, Color.yellow);
        if (glanceMeter >= 1)
        {
            owner.switchState(EnemyScript.StateEnum.investigating, player);
            glanceMeter = 0;

        }


    }
}
