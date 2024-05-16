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
    }

    // Update is called once per frame
    void Update()
    {
        if (ManagementScript.instance.chosenOne != null) { arrow.transform.LookAt(ManagementScript.instance.chosenOne.transform.position); }
    }
}
