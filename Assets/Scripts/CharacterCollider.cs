using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

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
			using(StreamWriter sw = File.AppendText(fileNameScore))
			{
				string timeStr = chronoText.GetComponent<HandleChrono> ().getStrTime ();
				sw.WriteLine(pseudoInput.text + " : " + timeStr);          
			}

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
		listScoreText.text = "";

		// Read the file and display it line by line.
		string line;
		StreamReader file = new StreamReader(fileNameScore);
		while((line = file.ReadLine()) != null)
			listScoreText.text += line + "\n";

		file.Close();
	}
}
