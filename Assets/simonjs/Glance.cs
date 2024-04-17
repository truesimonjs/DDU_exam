using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glance : MonoBehaviour
{
    public static void glance(ref float glanceMeter,ref float glanceDecay,Sight[] sights)
    {
        float glanceChange = 0;
        foreach (Sight sight in sights)
        {
            List<Transform> detected = sight.activate();
            float Seestarget = detected.Count > 0 ? 1 : 0;
            glanceChange += sight.awareness * Seestarget * Time.deltaTime;

        }

        glanceMeter += glanceChange;
        if (glanceChange == 0) glanceMeter -= glanceDecay * Time.deltaTime;
        if (glanceMeter < 0) glanceMeter = 0;
       

       


    }
}
