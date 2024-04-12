using System.Collections.Generic;
using UnityEngine;

public class SenseMaster : MonoBehaviour
{
    public Sight sight;
    public Transform senseTarget;
    public float glanceMeter = 0;
    //adjustables
    private void Update()
    {
        List<Transform> detected = sight.activate();
        if (detected.Count > 0)
        {
            if (senseTarget == null) senseTarget = detected[0];
            
            if (senseTarget == detected[0]) glanceMeter += 0.1f * Time.deltaTime;

            return;
        }
        senseTarget = null;
        glanceMeter = 0;


        
    }
}
