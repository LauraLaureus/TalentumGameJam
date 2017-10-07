using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour {

    public GameObject[] prefabs;

    public void spawn()
    {
        Vector2 jitter = new Vector2(
                UnityEngine.Random.value,
                UnityEngine.Random.value
            );

        Vector2 nextSpawnPosition = (Vector2)this.transform.position + jitter;

        int random = (int)Mathf.Round(UnityEngine.Random.Range(0,prefabs.Length));

        Instantiate(prefabs[random], nextSpawnPosition, Quaternion.identity);
    }

    
}
