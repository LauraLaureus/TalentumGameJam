using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPowerDownBehaviour : MonoBehaviour {

    Rigidbody2D rb;
    Vector2 originalPosition;

    public float maxDistance;
    Vector2 direction;
    public float speed;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;

        maxDistance = 3f;
      

        if (UnityEngine.Random.value < 0.5)
        {
            direction = transform.right;
        }
        else
        {
            direction = -transform.right;
        }
    }


    private void FixedUpdate()
    {
        if (Vector2.Distance(originalPosition, transform.position) < 0.7 * maxDistance) { }
        else
            inverseDirection();

        rb.velocity = speed*direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        inverseDirection();
        rb.velocity = direction;
    }

    private void inverseDirection()
    {
        direction = -direction;
    }
}
