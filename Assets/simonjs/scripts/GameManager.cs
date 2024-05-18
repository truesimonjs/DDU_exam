using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //inspector
    public List<Transform> availablePatrols;
    public SJS_PlayerController player;
    public GameObject monsterPrefab;
    //
    public int score = 0;
    public static GameManager instance;
    [HideInInspector]
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
    public void spawnMonster(Vector3 position,GameObject prefab = null)
    {
        if (availablePatrols.Count <= 0) 
        {
            Debug.LogWarning("can't spawn monster because there's no available patrols!");
            return;
        }
        if (prefab == null) prefab = monsterPrefab;
        Transform patrol = availablePatrols[0];
        availablePatrols.RemoveAt(0);
        EnemyScript spawnee= Instantiate(prefab, position, Quaternion.identity).GetComponent<EnemyScript>();
        spawnee.switchState(EnemyScript.StateEnum.patrolling, patrol, true);

        
    }
}
