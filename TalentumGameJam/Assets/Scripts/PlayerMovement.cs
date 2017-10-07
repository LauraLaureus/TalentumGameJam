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


    private void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        Vector2 result = new Vector2();

        if (Input.GetKey(KeyCode.DownArrow))
        {
            result = Vector2.down;
            SendEvent(MovementEnum.Down);
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            result = Vector2.up;
            SendEvent(MovementEnum.Down);

        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            result = Vector2.right;
            SendEvent(MovementEnum.Down);

        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            result = Vector2.left;
            SendEvent(MovementEnum.Down);

        }
        else
        {
            result = Vector2.zero;
            SendEvent(MovementEnum.Idle);
        }

        rb.velocity = result;
	}

    private void SendEvent(MovementEnum e)
    {
        if (OnKeyPressed != null)
        {
            OnKeyPressed(e);
        }
    }
}
