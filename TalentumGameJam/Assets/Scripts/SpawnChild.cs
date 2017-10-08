using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChild : MonoBehaviour {

    public GameObject[] childs;
	
    public void spawnSelectedChild(int room, int pc)
    {
        for (int i = 0; i < childs.Length;i++) {
            if(UnityEngine.Random.value < mustSpawn(room)) {
                childs[i].transform.GetComponent<SpawnGenerator>().spawn();
            }
        }
    }
    private float mustSpawn(int room)
    {
        if (room < 4)
            return 0.25f;
        else if (room < 8)
            return UnityEngine.Random.Range(0.25f, 0.5f);
        else
            return UnityEngine.Random.Range(0.25f, 1f);

    }
}
