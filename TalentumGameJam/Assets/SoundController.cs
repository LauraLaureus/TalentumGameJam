using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour {

    AudioSource source;
    string currentValue;
    Text text;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        text = GetComponent<Text>();
        currentValue = text.text;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (!currentValue.Equals(text.text)) {
            source.Play();
            currentValue = text.text;
        }
        
	}
}
