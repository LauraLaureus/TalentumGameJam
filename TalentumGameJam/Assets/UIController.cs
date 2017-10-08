using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Transform player;
    public Text computerDisplay,lifeDisplay;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	void Update () {
        computerDisplay.text = player.GetComponent<HackerInfo>().currentComputerID+"-"+ player.GetComponent<HackerInfo>().currentRoomNum;
        lifeDisplay.text = "Lifes: " + gameManager.attempts;
	}
}
