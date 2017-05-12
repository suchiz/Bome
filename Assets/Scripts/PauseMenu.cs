using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {


	public GameObject respawnpoint;
	public GameObject pauseMenu;
	public GameObject settingsMenu;
	private CameraController cc;
	private AudioSource audio;
	private Quaternion spawnRot;
	private bool onPause = false;
	private bool onSettings = false;

	void Start () {
		pauseMenu.SetActive(false);
		settingsMenu.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
		cc = (CameraController)GameObject.Find ("Main Camera").GetComponent ("CameraController");
		audio = (AudioSource)GameObject.Find ("Main Camera").GetComponent<AudioSource> ();
		spawnRot = transform.rotation;
	}
	

	void Update () {
		
		if (Input.GetKeyDown ("escape") && !onPause && !onSettings) {
			Cursor.lockState = CursorLockMode.None;
			pauseMenu.SetActive (true);
			settingsMenu.SetActive (false);
			cc.enabled = false;
			Time.timeScale = 0;
			onPause = true;
		} else if (Input.GetKeyDown ("escape") && onPause && !onSettings) {
			continuePressed ();
		} else if (Input.GetKeyDown ("escape") && onPause && onSettings) {
			backPressed ();
		}


	}

	public void continuePressed (){
		Cursor.lockState = CursorLockMode.Locked;
		pauseMenu.SetActive(false);
		settingsMenu.SetActive(false);
		Time.timeScale = 1;
		cc.enabled = true;
		onPause = false;
	
	}

	public void quitPressed (){
		Application.Quit ();
	}

	public void restartPressed(){
		transform.position = respawnpoint.transform.position;
		transform.rotation = Quaternion.identity;
		continuePressed ();
	}

	public void settingPressed(){
		settingsMenu.SetActive(true);
		pauseMenu.SetActive(false);
		onSettings = true;
	}

	public void backPressed(){
		settingsMenu.SetActive(false);
		pauseMenu.SetActive(true);
		onSettings = false;
	}
}
