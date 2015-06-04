using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject Main;
	public GameObject singlePlayer;
	public GameObject multiPlayer;

	// Use this for initialization
	void Awake () {
	
		singlePlayer.GetComponent<Canvas> ().enabled = false;
		multiPlayer.GetComponent<Canvas> ().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	public void SinglePlayer(){

		singlePlayer.GetComponent<Canvas> ().enabled = true;
		Main.GetComponent<Canvas> ().enabled = false;

	}

	public void MultiPlayer() {

		multiPlayer.GetComponent<Canvas> ().enabled = true;
		Main.GetComponent<Canvas> ().enabled = false;

	}


	public void Quit(){

		Application.Quit();
				
	}

	public void Back() {

		singlePlayer.GetComponent<Canvas> ().enabled = false;
		multiPlayer.GetComponent<Canvas> ().enabled = false;
		Main.GetComponent<Canvas> ().enabled = true;

	}

	public void newGame(){

		Application.LoadLevel ("TD");

	}
}
