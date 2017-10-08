using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public void SpawnNewLevel(int room, int pc)
    {
        for (int child = 0; child < transform.childCount; child++)
        {
            transform.GetChild(child).GetComponent<SpawnChild>().spawnSelectedChild(room,pc);
        }
    }

    public void CleanStage()
    {
        for (int child = 0; child < transform.childCount; child++)
        {
            transform.GetChild(child).GetComponent<SpawnChild>().Clean();
        }

    }
}
