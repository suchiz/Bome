using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

	public float speed = 5.0f;
	public float jumpForce = 6.5f;
	public Rigidbody rb;

	private Vector3 jump;
	private bool jumping = false;


	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		rb = GetComponent<Rigidbody> ();
		jump = new Vector3 (0, jumpForce, 0);

	}
	
	// Update is called once per frame
	void Update () {

		//Move right + left
		float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		transform.Translate (moveX, 0, moveZ);


		//Jump
		if (Input.GetKeyDown (KeyCode.Space) && !jumping) {
			rb.velocity += jump;
			jumping = true;
		}
		jumping = false;

		//Quit first person
		if (Input.GetKeyDown("escape"))
			Cursor.lockState = CursorLockMode.None;
		
	}
}
