using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Linq;

public class CharacterCollider : MonoBehaviour {

	public GameObject winText;
	public GameObject chronoText;
	public InputField pseudoInput;
	public Canvas scoreCanvas;
	public Text listScoreText;


	private string fileNameScore;
	private FirstPersonController fp;
	private CameraController cc;
	private bool allowEnter = false;

	void Start (){
		winText.SetActive (false);
		fileNameScore = "score.txt";
		pseudoInput.text = "Enter your pseudo ...";
		fp = GetComponent<FirstPersonController> ();
		scoreCanvas.gameObject.SetActive(false);
		cc = (CameraController)GameObject.Find ("Main Camera").GetComponent ("CameraController");
	}

	void Update()
	{
		if (allowEnter && Input.GetKeyDown (KeyCode.Return)) {
			pseudoInput.gameObject.SetActive (false);
			allowEnter = false;

			//We save the score in a file     
			string timeStr = chronoText.GetComponent<HandleChrono> ().getStrTime ();
			insert (timeStr, pseudoInput.text);

			winText.SetActive (false);

			//Display all the scores
			scoreCanvas.gameObject.SetActive(true);
			displayScore ();

		}
		else {
			allowEnter = pseudoInput.isFocused;
		}

	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Flag") {
			winText.SetActive (true);

			//Display the cursor and desactivate the player Controller
			Cursor.lockState = CursorLockMode.None;
			cc.enabled = false;
			fp.enabled = false;

			// We stop the chrono
			chronoText.GetComponent<HandleChrono> ().enabled = false;
		}
	}

	void displayScore()
	{
		int cpt = 0;
		listScoreText.text = "";

		// Read the file and display it line by line.
		string line;
		StreamReader file = new StreamReader(fileNameScore);
		while ((line = file.ReadLine ()) != null && cpt < 10) {
			listScoreText.text += line + "\n";
			cpt++;
		}
		file.Close();
	}


	void insert (string timeStr, string pseudoInput){

		bool stop = false; // we found the index
		var time_parts = timeStr.Split (':');// split the score to take apart minutes/secondes/mill
		List<string> list = new List<string>();
		list = File.ReadAllLines (fileNameScore).ToList ();
		int a, b, index = 0;

		for (int i = 0; i < list.Count && !stop; i++) {
			var score_parts = list [i].Split (':');// split pseudo/min/sec/mil

			a = Int32.Parse (time_parts [0]);
			b = Int32.Parse (score_parts [1]);
			stop = (a < b);
			if (a == b) {
				a = Int32.Parse (time_parts [1]);
				b = Int32.Parse (score_parts [2]);
				stop = (a < b);
				if (a == b) {
					a = Int32.Parse (time_parts [2]);
					b = Int32.Parse (score_parts [3]);
					stop = (a < b);
				}
			}
			index++;
		}

		if (stop)
			list.Insert (index - 1, (pseudoInput + ": " + timeStr));
		else
			list.Insert (index, (pseudoInput + ": " + timeStr));

		File.WriteAllLines (fileNameScore, list.ToArray());
	}

	public void restartPressed(){
		winText.SetActive (false);
		scoreCanvas.gameObject.SetActive(false);
		cc.enabled = true;
		fp.enabled = true;
		Cursor.lockState = CursorLockMode.Locked;
		chronoText.GetComponent<HandleChrono> ().enabled = true;
	}
}
