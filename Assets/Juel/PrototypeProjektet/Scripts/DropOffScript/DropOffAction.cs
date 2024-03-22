using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffAction : MonoBehaviour
{
    [SerializeField] private List<Material> materials;

    public bool ActiveDropOffLocation;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (ActiveDropOffLocation && collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerController>().HasTrash)
        {
            collision.gameObject.GetComponent<PlayerController>().score += collision.gameObject.GetComponent<PlayerController>().numOfTrashInBag;
            collision.gameObject.GetComponent<PlayerController>().numOfTrashInBag = 0;
            this.gameObject.GetComponent<Renderer>().material = materials[0];
            ActiveDropOffLocation = false;
            Debug.Log(message: "Trash was correctly disposed of");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(!ActiveDropOffLocation && collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponent<Renderer>().material = materials[2];
        }
    }
}
