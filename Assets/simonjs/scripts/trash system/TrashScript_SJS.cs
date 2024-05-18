using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript_SJS : MonoBehaviour
{
    public TrashType myTrash = TrashType.Plastic;
    private void OnTriggerEnter(Collider other)
    {
        IPickTrash target = other.gameObject.GetComponent<IPickTrash>();
        if (target == null) return;
        Debug.Log(other.gameObject.name);
        if (target.AddTrash(myTrash))
        {
            Destroy(gameObject);
        }

    }
}
public enum TrashType
{
    Plastic,Glass
}
