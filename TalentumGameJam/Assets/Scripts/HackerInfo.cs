using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackerInfo : MonoBehaviour{


    public int currentComputerID { get; set; }
    public int currentRoomNum { get; set; }
    public List<SequenceGenerator.SequenceElement> currentSequence;



    public void Start()
    {
        currentComputerID = 0;
        currentRoomNum = 0;
        currentSequence = new List<SequenceGenerator.SequenceElement>();
    }

    public void GetNextSequence(int length)
    {
        currentSequence = SequenceGenerator.generateSequence(length);
    }


    public bool matchElement(SequenceGenerator.SequenceElement element)
    {
        if (currentSequence[0] == element)
        {
            this.currentSequence.RemoveAt(0);
            return true;
        }
        else
            return false;
    }

    public bool didFinishSequence() {
        return currentSequence.Count == 0;
    }
}
