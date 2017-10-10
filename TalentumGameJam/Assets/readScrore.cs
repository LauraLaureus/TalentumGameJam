using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readScrore : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
        HackerInfo info = GameObject.Find("GameManager").GetComponent<GameManager>().info;
        this.GetComponent<Text>().text = " " + ((info.currentComputerID + 1)*info.currentRoomNum).ToString() + "CRYPTO COINS";
	}
	
	
}
