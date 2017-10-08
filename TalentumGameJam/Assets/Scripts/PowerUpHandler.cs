using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour {

    public float addition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameObject.Find("Timer").transform.GetChild(0).GetComponent<TimerController>().editTime(addition);
            Destroy(this.gameObject);
        }
    }
}
