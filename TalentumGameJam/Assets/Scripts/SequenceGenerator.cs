using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceGenerator {

    public enum SequenceElement
    {
        N,
        S,
        E,
        O
    }


    public static List<SequenceElement> generateSequence(int length)
    {
        List<SequenceElement> result = new List<SequenceElement>();

        for (int i = 0; i < length; i++)
        {
            result.Add(gen());
        }

        return result;
    }

    private static SequenceElement gen()
    {
        int r = (int)Mathf.Round(UnityEngine.Random.Range(1f, 4f));

        switch (r)
        {
            case 1:
                return SequenceElement.N; 
            case 2:
                return SequenceElement.S; 
            case 3:
                return SequenceElement.E; 
            default:
                return SequenceElement.O; 
        }
    }
}
