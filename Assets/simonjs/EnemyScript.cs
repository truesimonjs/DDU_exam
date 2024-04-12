using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //ref
 
    //
    public PatrolState patrol;
    public InvestigateState investi;
    public StateEnum state;


    private void Start()
    {

        switchState(StateEnum.patrolling, null, true);
    }
    private void Update()
    {
        switch (state)
        {
            case StateEnum.patrolling:
                patrol.StateUpdate();
                break;
            case StateEnum.investigating:
                investi.StateUpdate();
                break;
            case StateEnum.chasing:
              
                break;
            default:
                break;
        }
    }

    public void switchState(StateEnum newState, Transform target = null, bool priority = false)
    {
        switch (newState)
        {
            case StateEnum.patrolling:
                if (priority)
                {
                    state = StateEnum.patrolling;
                    patrol.StateStart();
                }
                break;
            case StateEnum.investigating:
                if (priority || state != StateEnum.chasing)
                {
                    state = StateEnum.investigating;
                    investi.StateStart(target);
                }
                break;
            case StateEnum.chasing:
                Debug.Log("startChase!");
                break;
            default:
                break;
        }
    }
 
    public enum StateEnum
    {
        patrolling, investigating, chasing
    }

}
