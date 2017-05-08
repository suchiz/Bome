using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollider : MonoBehaviour {

	public GameObject winText;

	void Start (){
		winText.SetActive (false);
	}

	void OnTriggerEnter (Collider other){
		if(other.gameObject.tag == "Flag")
			winText.SetActive (true);
	}
}
