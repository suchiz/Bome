using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour {

	public AudioClip jump;
	public AudioSource charactersource;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
		if (Input.GetKeyDown ("space")) {
			charactersource.PlayOneShot (jump);
		}

	}
}
