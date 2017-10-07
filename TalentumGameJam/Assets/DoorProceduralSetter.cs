using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorProceduralSetter : MonoBehaviour {

    public SequenceGenerator.SequenceElement element;

    // Use this for initialization
    void Start () {
	}

    public void SetElement(SequenceGenerator.SequenceElement element)
    {
        this.element = element;
        checkRotationForElement(element);
    }

    private void checkRotationForElement(SequenceGenerator.SequenceElement element)
    {
        switch (element) {
            case SequenceGenerator.SequenceElement.S:
                this.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case SequenceGenerator.SequenceElement.E:
                this.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;

            case SequenceGenerator.SequenceElement.O:
                this.transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            default:
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
