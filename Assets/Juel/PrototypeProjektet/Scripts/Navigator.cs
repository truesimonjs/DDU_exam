using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    [SerializeField] GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        arrow = GameObject.FindGameObjectWithTag("Navigator");
        arrow.GetComponentInChildren<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ManagementScript.instance.chosenOne != null)
        { 
            arrow.GetComponentInChildren<Renderer>().enabled=true;
            arrow.transform.LookAt(ManagementScript.instance.chosenOne.transform.position); 
        }
        else
        {
            arrow.GetComponentInChildren<Renderer>().enabled=false;
        }

    }
}
