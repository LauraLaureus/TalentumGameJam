using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    SpawnController proceduralGenerator;
    GameObject player;
    int currentLength = 4;
    HackerInfo info;
    public int attempts = 3;
    TimerController timer;
    List<SequenceGenerator.SequenceElement> sequence;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);

        timer = GameObject.Find("Timer").transform.GetChild(0).GetComponent<TimerController>();
        player = GameObject.Find("Player");

        proceduralGenerator = GameObject.Find("ProceduralController").GetComponent<SpawnController>();
        info = player.GetComponent<HackerInfo>();

        sequence = SequenceGenerator.generateSequence(4);

        debugPrint();

        //playSequence();

        proceduralGenerator.SpawnNewLevel(info.currentRoomNum,info.currentComputerID);
	}

    private void debugPrint()
    {
        string seq = String.Empty;
        for (int i = 0; i < sequence.Count; i++)
        {
            seq += " " + sequence[i].ToString() + " "; 
        }
        Debug.Log("Current Sequence:" + seq);
    }

    public void matchElement(SequenceGenerator.SequenceElement el)
    {
        player.GetComponent<HackerInfo>().currentSequence = info.currentSequence;


        if (sequence[0] == el)
        {
            sequence.RemoveAt(0);
            if (sequence.Count == 0)
            {
                info.currentComputerID += 1;
                timer.resetTimer();

                proceduralGenerator.CleanStage();
                info.currentSequence = SequenceGenerator.generateSequence(4);
                //playSequence();
                proceduralGenerator.SpawnNewLevel(info.currentRoomNum, info.currentComputerID);
                timer.activeTimer = true;
                //TODO actualizar el player
            }
            else
            {
                info.currentRoomNum += 1;
                proceduralGenerator.CleanStage();
                proceduralGenerator.SpawnNewLevel(info.currentRoomNum, info.currentComputerID);
                //TODO actualizar el player
            }
        }
        else
        {
            attempts -= 1;
            //TODO update life. 
        }
    }


    public void ResetLevel()
    {
        HackerInfo info = player.GetComponent<HackerInfo>();

        //TODO update UI

        proceduralGenerator = GameObject.Find("ProceduralController").GetComponent<SpawnController>();
        proceduralGenerator.SpawnNewLevel(info.currentRoomNum, info.currentComputerID);

    }

}
