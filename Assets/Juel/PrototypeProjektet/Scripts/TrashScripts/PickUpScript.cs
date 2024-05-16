using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    private int PlayerAmountOfTrashCollected;
  
    public List<Material> colorList;
    

    
    private void Activate()
    {
        int i = Random.Range(0, ManagementScript.instance.DropOffList.Count);
        ManagementScript.instance.chosenOne = ManagementScript.instance.DropOffList[i];
        ManagementScript.instance.DropOffList[i].GetComponent<Renderer>().material = ManagementScript.instance.colors[1];
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
                ManagementScript.instance.trashList.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
            else
                Debug.Log("PickUP - Failed");
        }
    }
}
