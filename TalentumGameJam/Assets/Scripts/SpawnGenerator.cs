using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour {

    public GameObject[] prefabs;
    public bool randomizeSpeed;

    private GameObject obj;

    public void spawnSelectedChild()
    {
        Vector2 jitter = new Vector2(
                UnityEngine.Random.value,
                UnityEngine.Random.value
            );

        Vector2 nextSpawnPosition = (Vector2)this.transform.position + jitter;

        int random = (int)Mathf.Round(UnityEngine.Random.Range(0,prefabs.Length));

        if (prefabs.Length > 0)
            obj = Instantiate(prefabs[random], nextSpawnPosition, Quaternion.identity);
        else
            obj = null;

        if (randomizeSpeed)
        {
            
            obj.GetComponent<DynamicPowerDownBehaviour>().maxDistance = UnityEngine.Random.Range(
                                                                        0,
                                                                        3);
            obj.GetComponent<DynamicPowerDownBehaviour>().speed = UnityEngine.Random.value;
        }
    }

    public void Clear() {
        if (obj != null)
            Destroy(obj);
    }

    
}
