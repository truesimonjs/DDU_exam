using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funnyMovementScript : MonoBehaviour
{
    float x;
    float y;
    float z;
    float i;
    [SerializeField] float delayTime;

    IEnumerator moveSpawnPos()
    {
        while (true)
        {
            x = Random.Range(-100f, 100f);
            y = Random.Range(15f, 40f);
            z = Random.Range(-100f, 100f);
            yield return new WaitForSeconds(delayTime);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moveSpawnPos());
        i = 0;
    }

    private void Update()
    {
        i++;
        transform.position = new Vector3(x += i%2, y += 0.01f, z += (2 % 8 * 3) / 3);
    }
}
