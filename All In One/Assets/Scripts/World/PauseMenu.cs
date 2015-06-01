using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public static GameObject PauseScreen;
	public static GameObject UI;
	public static bool paused = false;



	void Awake(){

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

		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			Cursor.visible = false;
			PauseScreen.GetComponent<Canvas>().enabled = false;
			UI.SetActive (true);
			paused = false;
		}
		else
		{
			Time.timeScale = 0f;
			Cursor.visible = true;
			UI.SetActive (false);
			PauseScreen.GetComponent<Canvas>().enabled = true;
			paused = true;   
		}
	}


	public void Quit(){
		Time.timeScale = 1f;
		Application.Quit();


	}

}
