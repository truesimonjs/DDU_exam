using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementScript : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private List<GameObject> DropOffList;
    [SerializeField] private List<Material> colors;
    


    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().numOfTrashInBag <= 0)
        {
            for(int i = 0; i< DropOffList.Count; i++)
            {
                DropOffList[i].GetComponent<Renderer>().material = colors[0];
            }
        }
    }
}
