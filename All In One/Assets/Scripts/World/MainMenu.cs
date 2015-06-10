using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject Main;
	public GameObject singlePlayer;
	public GameObject multiPlayer;
	public GameObject join;

	// Use this for initialization
	void Awake () {
	
		singlePlayer.GetComponent<Canvas> ().enabled = false;
		multiPlayer.GetComponent<Canvas> ().enabled = false;
		join.GetComponent<Canvas> ().enabled = false;
	
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
		join.GetComponent<Canvas> ().enabled = false; //verander dat nie altyd terug main toe gaan nie
		Main.GetComponent<Canvas> ().enabled = true;

	}

	public void newGame(){

		Application.LoadLevel ("TD");

	}

	public void Host(){
		string serverName;

		//serverName = GameObject.Find ("serverName").GetComponent<Text>().text;
		//GameObject.Find ("Control").GetComponent<NetworkManager> ().StartServer ();

	}

	public void joinClick(){

		join.GetComponent<Canvas> ().enabled = true;
		multiPlayer.GetComponent<Canvas> ().enabled = false;

	}
}
