using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Transform player;
    public Text computerDisplay;
   	
	void Update () {
        computerDisplay.text = player.GetComponent<HackerInfo>().currentComputerID+"-"+ player.GetComponent<HackerInfo>().currentRoomNum;
	}
}
