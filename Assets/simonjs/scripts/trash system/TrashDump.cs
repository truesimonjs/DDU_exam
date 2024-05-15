using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDump : MonoBehaviour
{
    public TrashType dumpType = TrashType.Plastic;
    private void OnTriggerEnter(Collider other)
    {
        
        SJS_PlayerController player = other.gameObject.GetComponent<SJS_PlayerController>();
        if (player==null) return;
        if (player.backPack.Contains(dumpType))
        {
            for (int i = player.backPack.Count-1; i >=0; i--)
            {
                if (player.backPack[i] == dumpType)
                {
                    GameManager.instance.score += 1;
                    player.backPack.RemoveAt(i);
                }
            } 
        }
        
    }
}
