using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public enum MovementEnum
    {
        Up,
        Down,
        Right,
        Left,
        Idle
    }

    Rigidbody2D rb;

    public delegate void KeyPressedEvent(MovementEnum e);
    public static KeyPressedEvent OnKeyPressed;

    public float  speed;
    private void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        Vector2 result = new Vector2(0,0);
       

        if (Input.GetKey(KeyCode.DownArrow))
        {
            result = (Vector2)transform.up;
            transform.rotation = Quaternion.Euler(0, 0, 180);
            //this.transform.localScale = new Vector3(1, -1, 1);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            result = (Vector2)transform.up;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //this.transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            result = (Vector2)transform.up;
            transform.rotation = Quaternion.Euler(0, 0, -90);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            result = (Vector2)transform.up;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        rb.velocity = speed * result;
	}

    private void SendEvent(MovementEnum e)
    {
        if (OnKeyPressed != null)
        {
            OnKeyPressed(e);
        }
    }
}
