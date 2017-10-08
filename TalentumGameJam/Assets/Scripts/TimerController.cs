using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

    private Text timerText;
    private bool didEventSent = false;

    public bool activeTimer = true;
    
    public float defaultValue = 30f;

    public delegate void TimerEvent();
    public static TimerEvent onTimerEnd; 
	void Start () {
        timerText = GetComponent<Text>();
    }
	void Update () {
        updateTimer();
	}
    private void updateTimer()
    {
        if (activeTimer)
        {

            if(mustReduceTime()) {
                reduceTimer();
            }else {
                timerText.text = "0.00";
                if(!didEventSent) sendEvent();                       
            }
        }
    }
    private bool mustReduceTime()
    {
        return float.Parse(this.timerText.text) > 0;
    }
    private void reduceTimer()
    {
        timerText.text = (float.Parse(timerText.text) - Time.deltaTime).ToString("F2");
    }
    private void sendEvent()
    {
        didEventSent = true;
        Debug.Log("Attempt to send timer event");
        if(onTimerEnd != null) {
            onTimerEnd();
        }
    }
    public void setTimerText(string timerText)
    {
        this.timerText.text = timerText;
    }
    public string getTimerText()
    {
        return this.timerText.text;
    }
    public void editTime(float addition)
    {
        this.timerText.text = (float.Parse(timerText.text) + addition).ToString("F2");
    }

    public void resetTimer(bool active = false)
    {
        timerText.text = defaultValue.ToString("F2");
        activeTimer = active;
    }
}
