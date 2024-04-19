using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ChaseScript : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;
    [SerializeField] private Vector3 lookAtPos;



    // Update is called once per frame
    private void Update()
    {
        lookAtPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        

        agent.SetDestination(target.transform.position);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
