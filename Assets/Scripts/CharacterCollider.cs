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
		while ((line = file.ReadLine ()) != null && cpt < 5) {
			listScoreText.text += line + "\n";
			cpt++;
		}
		file.Close();
	}

	void insert (string timeStr, string pseudoInput){
		
		var time_parts = timeStr.Split (':');// split the score to take apart minutes/secondes/mill
		List<string> list = new List<string>();
		list = File.ReadAllLines (fileNameScore).ToList (); //put all the lines in a list

		StreamReader file = new StreamReader (fileNameScore);
		string line;
		bool stop = false; //found the index
		int a, b, index = 0;

		while ((line = file.ReadLine ()) != null && !stop) {
			var score_parts = line.Split (':');
			for (int i = 0; i < 2 && !stop; i++) {
				a = Int32.Parse (time_parts [i]);//i because min:sec:mill
				b = Int32.Parse (score_parts [i + 1]);//i+1 because speudo:min:sec:mill
				stop = ( a < b); 
			}
			index++;
		}

		list.Insert (index, (pseudoInput + " : " + timeStr));
		File.WriteAllLines (fileNameScore, list.ToArray());
	}

}
