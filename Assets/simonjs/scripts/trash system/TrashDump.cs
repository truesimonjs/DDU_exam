using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDump : MonoBehaviour
{
    public TrashType dumpType = TrashType.Plastic;
    public static List<Transform> activeDumps = new List<Transform>();
    //debug
    public List<Transform> debugdumps;
    private void Update()
    {
        debugdumps = activeDumps;
    }
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
                    GameManager.instance.backPackChange(dumpType, false);
                }
            } 
        }
        
    }
    public void BecomeActive(bool active)
    {
        GetComponent<MeshRenderer>().material.color = active ? Color.green : Color.red;
        if (active)
        {
            activeDumps.Add(transform);
        } else
        {
            activeDumps.Remove(transform);
        }
    }
}
