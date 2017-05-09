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
	}
	
	// Update is called once per frame
	void Update () {
		chronoCount = Time.timeSinceLevelLoad;
		displayChrono ();
	}

	void displayChrono()
	{
		chrono.text = "Time: " + chronoCount.ToString("F2");
	}
}
