using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour
{
    public bool t;
    public PatrolState patrol;
    public InvestigateState investi;
   //
    public Sight sight;
    public StateEnum state = StateEnum.patrolling;
    //glance
    public float glanceMeter;
    public Transform glanceTarget;
  
    private void Start()
    {
        
        t = true;
    }
    private void Update()
    {
        switch (state)
        {
            case StateEnum.patrolling:
                patrol.StateUpdate();
                break;
            case StateEnum.investigating:

                break;
            case StateEnum.chasing:
                break;
            default:
                break;
        }



    }

    public void glance()
    {
        List<Transform> detected = sight.activate();
        if (detected.Count > 0)
        {
            if (glanceTarget == null) glanceTarget = detected[0];

       
            float Seestarget = glanceTarget == detected[0] ? 1 : -1;
            glanceMeter += 0.1f * Seestarget * Time.deltaTime;
            if (glanceMeter >= 1)
            {
                glanceMeter = 0;
                investi.StateStart(glanceTarget.position);
                t = false;
            }
        }
      
    }
    public void spot()
    {
       
    }
    public enum StateEnum
    {
        patrolling,investigating,chasing
    }

}
