using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPhysicHandler : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerAction(collision);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //TriggerAction(collision);
        Debug.Log("TriggerExit");
    }

    private void TriggerAction(Collider2D collision)
    {

        if (collision.gameObject.tag != "Room")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().matchElement(
                this.GetComponent<DoorProceduralSetter>().element
                );
        }
    }
}
