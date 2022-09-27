using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBunnyBehavior : MonoBehaviour
{
	[Header("Bunnies")]
	public float speed = 0.05f;
	public bool goingForward = true;
	public Rigidbody rb;
	private float jumpForce = 10;
	private bool turnAround = false;
	private int bunnyLayer = 7;

    private void Start()
    {
		Physics.IgnoreLayerCollision(bunnyLayer, bunnyLayer, true);
		rb = GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
    {
		Move();

        if (turnAround)
        {
			speed = -speed;
			turnAround = false;	
        }
    }

	private void Move()
	{
		if (goingForward)
		{
			rb.transform.position += new Vector3(0, 0, speed);
		}
        else
        {
			rb.transform.position += new Vector3(speed, 0, 0);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Goal")
		{
			Destroy(this.gameObject);
		}

		if (other.gameObject.tag == "BouncePad")
        {
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Death")
        {
			Destroy(this.gameObject);
        }

		if (collision.collider.tag == "Wall")
		{
			turnAround = true;
		}

		if (collision.collider.tag == "CornerBottomRight")
		{
			if (goingForward)
			{
				goingForward = false;
			}
            else if (!goingForward)
			{ 
				goingForward = true;
			}
		}

		if(collision.collider.tag == "CornerBottomLeft")
        {
			if (goingForward)
            {
				goingForward = false;
				turnAround = true;
            }
			else if (!goingForward)
            {
				goingForward = true;
				turnAround = true;
            }
        }

		if (collision.collider.tag == "CornerUpperRight")
		{
			if (goingForward)
			{
				goingForward = false;
				turnAround = true;
			}
			else if (!goingForward)
			{
				goingForward = true;
				turnAround = true;
			}
		}

		if (collision.collider.tag == "CornerUpperLeft")
		{
			if (goingForward)
			{
				goingForward = false;
			}
			else if (!goingForward)
			{
				goingForward = true;
			}
		}
	}
}
