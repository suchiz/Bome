using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleChrono : MonoBehaviour {
	Text chrono;
	private float chronoCount;

	// Use this for initialization
	void Start () {
		chrono = GetComponent<Text> ();
		chronoCount = 0;
		displayChrono ();
		Debug.Log ("Here : " + chrono.text);
	}
	
	// Update is called once per frame
	void Update () {
		chronoCount += Time.deltaTime;
		displayChrono ();
		Debug.Log ("Update : " + chrono.text);
	}

	void displayChrono()
	{
		chrono.text = chronoCount.ToString();
	}
}
