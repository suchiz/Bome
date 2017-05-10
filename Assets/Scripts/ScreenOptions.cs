using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenOptions : MonoBehaviour {
	
	private List<string> resolutions = new List<string>() {"800x600", "1024x768"};
	private bool windowed;
	private int resolution_chosen = 0;
	public Dropdown dropdown;

	void Start () {
		dropdown.AddOptions (resolutions);
	}
	
	// Update is called once per frame
	void Update () {

		if (windowed) {
			if (resolution_chosen == 0)
				Screen.SetResolution (800, 600, false);
			else if (resolution_chosen == 1)
				Screen.SetResolution (1024, 768, false);
		} else {
			if (resolution_chosen == 0)
				Screen.SetResolution (800, 600, true);
			else if (resolution_chosen == 1)
				Screen.SetResolution (1024, 768, true);
		}
	}

	public void setIndex (int index){
		resolution_chosen = index;
	}

	public void setWindowed (bool isOn){
		windowed = isOn;
	}
}
