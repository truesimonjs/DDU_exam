using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SJS_PlayerController player;
    public int score = 0;
    public static GameManager instance;
    //  [HideInInspector]
    public TrashDump[] trashDumpList;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        trashDumpList = FindObjectsByType<TrashDump>(FindObjectsInactive.Include,FindObjectsSortMode.None);
    }
    public void backPackChange(TrashType trash,bool hasTrashType)
    {
        foreach (TrashDump dump in trashDumpList)
        {
            if (dump.dumpType == trash)
            {
                dump.BecomeActive(hasTrashType);
            }
        
           
        }
    }
}
