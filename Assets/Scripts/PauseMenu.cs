using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseMenu;
	CameraController cc;


	void Start () {
		pauseMenu.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
		cc = (CameraController)GameObject.Find ("Main Camera").GetComponent ("CameraController");
	}
	

	void Update () {
		
		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
			pauseMenu.SetActive(true);
			cc.enabled = false;
			Time.timeScale = 0;
		}
	}

	public void continuePressed (){
		pauseMenu.SetActive(false);
		Time.timeScale = 1;
		cc.enabled = true;
	}

	public void quitPressed (){
		Application.Quit ();
	}

	public void restartPressed(){
		Application.LoadLevel (0);
		Time.timeScale = 1;
		cc.enabled = true;
	}
}
