using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour {

    public float addition;

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject.Find("Timer").transform.GetChild(0).GetComponent<TimerController>().editTime(addition);
        Destroy(this.gameObject);
    }
}
