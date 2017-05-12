using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleChrono : MonoBehaviour {
	Text chrono;
	private bool win = false;
	private float chronoCount;
	private float startime;
	// Use this for initialization
	void Start () {
		chrono = GetComponent<Text> ();
		startime = Time.time;
		displayChrono ();
	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate()
	{
		if (!win) {
			chronoCount = Time.time - startime;
			displayChrono ();
			return;
		}

		// if win

	}

	void displayChrono()
	{

		chrono.text = "Time: " + getStrTime();
	}

	public string getStrTime()
	{
		TimeSpan t = TimeSpan.FromSeconds(chronoCount);
		string timeStr = string.Format("{1:D2}:{2:D2}:{3:D3}",
			t.Hours, 
			t.Minutes, 
			t.Seconds, 
			t.Milliseconds);

		return timeStr;
		
	}

	public void resetTime () {
		startime = Time.time;
	}
		
}
