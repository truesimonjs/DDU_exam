using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    private int PlayerAmountOfTrashCollected;
    [SerializeField] private GameObject manager;

    public List<Material> colorList;
    public List<GameObject> DropOff;

    private void Activate()
    {
        int i = Random.Range(0, DropOff.Count);
        DropOff[i].GetComponent<DropOffAction>().ActiveDropOffLocation = true;
        DropOff[i].GetComponent<Renderer>().material = colorList[1];
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerController>().CanPickUpTrash)
        {
                PlayerAmountOfTrashCollected = collision.gameObject.GetComponent<PlayerController>().numOfTrashInBag;
                if (collision.gameObject.GetComponent<PlayerController>().HasTrash == false) { Activate(); }
                collision.gameObject.GetComponent<PlayerController>().numOfTrashInBag += 1;

                if (PlayerAmountOfTrashCollected < collision.gameObject.GetComponent<PlayerController>().numOfTrashInBag)
                {
                    
                    Destroy(this.gameObject);
                }
                else
                    Debug.Log("PickUP - Failed");
            }
    }   
}
