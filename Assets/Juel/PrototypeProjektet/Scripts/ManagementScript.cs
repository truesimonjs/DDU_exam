using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ManagementScript : MonoBehaviour
{
    public int lvl;
    public static ManagementScript instance;
    public List<GameObject> trashPrefabList;
    public List<GameObject> trashSpawnPosList;
    //[SerializeField] private GameObject player;
    //public GameObject chosenOne;


    //public List<GameObject> DropOffList;
    public List<GameObject> trashList;
    //public List<Material> colors;
    


    [SerializeField] private float spawnDelayTime;
    [SerializeField] private bool lvlComplete;

    private void Awake()
    {
        instance = this;
    }

    //Color rColor;
    //public Material rMaterial;

    private void Start()
    {
        lvlComplete = true;
        StartCoroutine(spawnTrash());
    }

    IEnumerator spawnTrash()
    {
        while (true)
        {
            if (lvlComplete)
            {
                spawnTrashAction();
                lvl++;
            }
            yield return new WaitForSeconds(spawnDelayTime);
        
        }   
    }

    void spawnTrashAction()
    {
        foreach (GameObject obj in trashSpawnPosList)
        {
            int spawnPoint = Random.Range(0, trashSpawnPosList.Count);
            GameObject newGO = Instantiate(trashPrefabList[Random.Range(0, trashPrefabList.Count)], trashSpawnPosList[spawnPoint].transform.position, Quaternion.identity);
            trashList.Add(newGO);
        }
            
        //rMaterial = newGO.GetComponent<Renderer>().material;
        //    for (int i = 0; i < 5; i++) 
        //    { 
        //        if (i == 0) 
        //        { 
        //            rColor.r = ((float)Random.Range(0, 255)) / 255; 
        //        }
        //        else if(i == 1) 
        //        { 
        //            rColor.g = ((float)Random.Range(0, 255))/255; 
        //        } 
        //        else if (i == 2) 
        //        { 
        //            rColor.b = ((float)Random.Range(0, 255))/255; 
        //        }
        //        else if(i == 3)
        //        {
        //            rMaterial.SetFloat("Metallic", ((float)Random.Range(0, 255)) / 255);
        //        }
        //        else if (i == 4)
        //        {
        //            rMaterial.SetFloat("Smoothness", ((float)Random.Range(0, 255)) / 255);
        //        }
        //    }
        //    rColor.a = 1;
        //    rMaterial.color = rColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (trashList.Count > 0) lvlComplete = false;
        else
             lvlComplete = true;
        
        //if (player.GetComponent<PlayerController>().numOfTrashInBag <= 0)
        //{
        //    for (int i = 0; i < DropOffList.Count; i++)
        //    {
        //        DropOffList[i].GetComponent<Renderer>().material = colors[0];
        //    }
        //}
    }
}
