using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChild : MonoBehaviour {

    public GameObject[] childs;
	
    public void spawnSelectedChild(int room, int pc)
    {
        for (int i = 0; i < childs.Length;i++) {
            if(mustSpawn()) {
                childs[i].transform.GetComponent<SpawnGenerator>().spawn();
            }
        }
    }
    private bool mustSpawn()
    {
        return true;
    }
}
