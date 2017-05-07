using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class FirstPersonController : MonoBehaviour {

	public float speed = 5.0f;
	public float jumpForce = 6.5f;
	public Rigidbody rb;

	private Vector3 jump;


	void Start () {
		rb = GetComponent<Rigidbody> ();
		jump = new Vector3 (0, jumpForce, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//Move right + left
		float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		transform.Translate (moveX, 0, moveZ);

		//deltaVelocityY = abs (rb.velocity.y - precedentVelocityY);

		//Jump
		if (Input.GetKeyDown (KeyCode.Space) && Math.Abs(rb.velocity.y) < 0.1) {
			rb.velocity += jump;
		}


		//Quit first person
	
		
	}
}
