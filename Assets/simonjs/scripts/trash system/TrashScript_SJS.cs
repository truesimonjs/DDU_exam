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
        if (target.addTrash(myTrash))
        {
            Destroy(gameObject);
        }

    }
}
public enum TrashType
{
    Plastic,Glass
}
