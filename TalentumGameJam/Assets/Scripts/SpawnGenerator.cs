using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour {

    public GameObject[] prefabs;
    public bool randomizeSpeed;

    public void spawn()
    {
        Vector2 jitter = new Vector2(
                UnityEngine.Random.value,
                UnityEngine.Random.value
            );

        Vector2 nextSpawnPosition = (Vector2)this.transform.position + jitter;

        int random = (int)Mathf.Round(UnityEngine.Random.Range(0,prefabs.Length));
        GameObject gO;

        if (prefabs.Length > 0)
            gO = Instantiate(prefabs[random], nextSpawnPosition, Quaternion.identity);
        else
            gO = null;

        if (randomizeSpeed)
        {
            
            gO.GetComponent<DynamicPowerDownBehaviour>().maxDistance = UnityEngine.Random.Range(
                                                                        0,
                                                                        3);
            gO.GetComponent<DynamicPowerDownBehaviour>().speed = UnityEngine.Random.value;
        }
    }

    
}
