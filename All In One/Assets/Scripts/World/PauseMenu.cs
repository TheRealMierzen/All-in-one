using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public static GameObject PauseScreen;
	public static GameObject UI;
	public static bool paused = false;



	void Awake(){
		//UnityEngine.GameObject UI = GameObject.FindWithTag ("UI");
		PauseScreen = GameObject.Find ("PauseScreen");
		UI = GameObject.Find ("UI");
		UI.SetActive (true);

		PauseScreen.GetComponent<Canvas>().enabled = false;


	}
	
	void Update()
	{
		if (Input.GetButtonDown ("Pause")) {
			togglePause ();
		}
	}
	
	void OnGUI()
	{
		if(paused)
		{

			GUILayout.Label("Game is paused!");
//			if(GUILayout.Button("Click me to resume"))
//				paused = togglePause();
		}
	}
	
	public void togglePause()
	{
		//GameObject panel = GameObject.Find ("pausePanel");

		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			Cursor.visible = false;
			PauseScreen.GetComponent<Canvas>().enabled = false;
			UI.SetActive (true);
			//UI.GetComponent<Canvas>().enabled = true;
			paused = false;
			//return(false);
		}
		else
		{
			Time.timeScale = 0f;
			Cursor.visible = true;
			UI.SetActive (false);
			//UI.GetComponent<Canvas>().enabled = false;
			PauseScreen.GetComponent<Canvas>().enabled = true;
			paused = true;
			//return(true);    
		}
	}


	public void Quit(){
		Time.timeScale = 1f;
		Application.Quit();


	}

}
