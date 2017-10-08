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

    public GameObject nextLevelPanel;

    private void OnEnable()
    {
        TimerController.onTimerEnd += OnTimerEnd_Reset;
    }

    private void OnTimerEnd_Reset()
    {
        attempts -= 1;

        if (attempts > 0)
        {
            info.currentRoomNum = 0;
            proceduralGenerator.CleanStage();
            sequence = SequenceGenerator.generateSequence(currentLength);
            debugPrint();
            proceduralGenerator.SpawnNewLevel(info.currentRoomNum, info.currentComputerID);
            player.transform.position = Vector2.zero;
            timer.resetTimer(true);
        }
        else {
            //TODO somthing pretty
        }
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);

        timer = GameObject.Find("Timer").transform.GetChild(0).GetComponent<TimerController>();
        timer.activeTimer = false;
        player = GameObject.Find("Player");

        proceduralGenerator = GameObject.Find("ProceduralController").GetComponent<SpawnController>();
        info = player.GetComponent<HackerInfo>();

        sequence = SequenceGenerator.generateSequence(currentLength);

        debugPrint();

        playSequence();

	}

    bool ready = true;
    int index = 0;    
    private void playSequence(bool resetState = false)
    {      
        if (resetState)
        {
            debugPrint();
            //timer.activeTimer = true;
            player.transform.position = Vector2.zero;
        }
        if (ready && index < sequence.Count) {
            ready = false;
            StartCoroutine("PlayDoor", selectDoor(sequence[index]));
        }
        if (index >= sequence.Count)
        {
            proceduralGenerator.SpawnNewLevel(info.currentRoomNum,info.currentComputerID);
            timer.activeTimer = true;
            index = 0;
        }
    }

    private GameObject selectDoor(SequenceGenerator.SequenceElement item)
    {

        switch(item)
        {
            case SequenceGenerator.SequenceElement.N:
                return GameObject.Find("NorthDoor");

            case SequenceGenerator.SequenceElement.O:
                return GameObject.Find("WestDoor");

            case SequenceGenerator.SequenceElement.S:
                return GameObject.Find("SouthDoor");

            //case SequenceGenerator.SequenceElement.E:
            default:  return GameObject.Find("EastDoor");

        }
    }

    private  IEnumerator PlayDoor(GameObject door)
    {
        door.GetComponent<Animator>().SetTrigger("doorMov");
        door.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        ready = true;
        index++;
        playSequence();
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


        if (sequence[0] == el)
        {
            sequence.RemoveAt(0);
            if (sequence.Count == 0)
            {
                Time.timeScale = 0;
                nextLevelPanel.SetActive(true);
                //TODO activate Panel 
            }
            else
            {
                info.currentRoomNum += 1;
                proceduralGenerator.CleanStage();
                proceduralGenerator.SpawnNewLevel(info.currentRoomNum, info.currentComputerID);

                spawnPlayerProperly(el);
            }
        }
        else
        {
            attempts -= 1;
            info.currentRoomNum = 0;

            debugPrint();
            timer.resetTimer();
            proceduralGenerator.CleanStage();
            sequence = SequenceGenerator.generateSequence(currentLength);
            playSequence(true);
            spawnPlayerProperly(el);

        }
    }

    public void activateAfterDialog()
    {
        nextLevelPanel.SetActive(false);
        Time.timeScale = 1;
        info.currentComputerID += 1;
        timer.resetTimer();

        proceduralGenerator.CleanStage();
        currentLength += 1;
        sequence = SequenceGenerator.generateSequence(currentLength);
        playSequence(true);
        
    }

    private void spawnPlayerProperly(SequenceGenerator.SequenceElement el)
    {
        switch (el)
        {
            case SequenceGenerator.SequenceElement.N:
                player.transform.position = (Vector2)GameObject.Find("SouthDoor").transform.position + 2 * Vector2.up;
                break;

            case SequenceGenerator.SequenceElement.O:
                player.transform.position = (Vector2)GameObject.Find("EastDoor").transform.position + 2 * -Vector2.right;
                break;

            case SequenceGenerator.SequenceElement.S:
                player.transform.position = (Vector2)GameObject.Find("NorthDoor").transform.position + 2 * Vector2.down;
                break;

            case SequenceGenerator.SequenceElement.E:
                player.transform.position = (Vector2)GameObject.Find("WestDoor").transform.position + 2 * Vector2.right;
                break;
        }
    }

    public void ResetLevel()
    {
        HackerInfo info = player.GetComponent<HackerInfo>();

        //TODO update UI

        proceduralGenerator = GameObject.Find("ProceduralController").GetComponent<SpawnController>();
        proceduralGenerator.SpawnNewLevel(info.currentRoomNum, info.currentComputerID);

    }


    private void OnDisable()
    {
        TimerController.onTimerEnd -= OnTimerEnd_Reset;
    }

}
