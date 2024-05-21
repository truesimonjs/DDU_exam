using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    [SerializeField] GameObject arrow;

    Transform target;
    Transform tmp_target;

    // Start is called before the first frame update
    void Start()
    {
        arrow = GameObject.FindGameObjectWithTag("Navigator");
        arrow.GetComponentInChildren<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(TrashDump.activeDumps.Count > 0)
        {
            float tmp_shortestDist = Mathf.Infinity;
            foreach(Transform t in TrashDump.activeDumps)
            {
                if(Vector3.Distance(t.position, this.gameObject.transform.position) < tmp_shortestDist)
                {
                    tmp_shortestDist = Vector3.Distance(t.position, this.gameObject.transform.position);
                    tmp_target = t;
                }
            }
            target = tmp_target;
            arrow.GetComponentInChildren<Renderer>().enabled=true;
            arrow.transform.LookAt(target.position);
            Debug.Log(target.name);

        }
        else
        {
            arrow.GetComponentInChildren<Renderer>().enabled=false;
        }

    }
}
