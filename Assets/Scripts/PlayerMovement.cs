using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public float speed;
	Animator anim;
	public Bounds boundary;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	
	// Update is called once per frame
	void Update() 
	{

	}

	void FixedUpdate()
	{
		//TODO: Animation
		if(boundary.Contains(transform.position))
		{
			var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			transform.position += move * speed * Time.deltaTime;
		}

    
		/*
				if (Input.GetKeyDown(KeyCode.W))
		{
			
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			
		}
		else if (Input.GetKeyDown(KeyCode.A))
		{
			
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			
		}
		 */

	}
}
