using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class InvestigateState : State
{
    //ref
    private NavMeshAgent agent;
    private EnemyScript owner;
    private Transform player;
    private Sight[] sights;
    //inspector values
    
    [SerializeField]private GameObject senses;
    [SerializeField] private float investigationTime;
    [SerializeField] private float TimePerSpot;
    [SerializeField] private float glanceDecay;
    //used vars
    private Vector3 point;
    private float nextMovement;
    private float timeSpent;
    private float glanceMeter;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        owner = GetComponent<EnemyScript>();
        sights = senses.GetComponents<Sight>();
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
            agent.SetDestination(point + new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3)));
            
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
