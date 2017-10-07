using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    SpawnController proceduralGenerator;
    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");

        proceduralGenerator = GameObject.Find("ProceduralController").GetComponent<SpawnController>();
        HackerInfo info = player.GetComponent<HackerInfo>();

        proceduralGenerator.SpawnNewLevel(info.currentRoomNum,info.currentComputerID);
	}


    public void ResetLevel()
    {
        HackerInfo info = player.GetComponent<HackerInfo>();

        //TODO update UI

        proceduralGenerator = GameObject.Find("ProceduralController").GetComponent<SpawnController>();
        proceduralGenerator.SpawnNewLevel(info.currentRoomNum, info.currentComputerID);

    }

}
