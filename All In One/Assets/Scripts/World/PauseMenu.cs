using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	//public GameObject panel;
	public static bool paused = false;



	void Start (){

		//panel = GameObject.Find ("pausePanel");
	}

	void Update()
	{
		if (Input.GetButtonDown ("Pause")) {
			paused = togglePause ();
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
	
	public static bool togglePause()
	{
		//GameObject panel = GameObject.Find ("pausePanel");

		if(Time.timeScale == 0f)
		{
			Debug.Log ("unpause");
			Time.timeScale = 1f;
			Cursor.visible = false;
			GameObject.Find ("pausePanel").SetActive (false);
			//panel.SetActive (false);
			return(false);
		}
		else
		{
			Debug.Log ("pause");
			Time.timeScale = 0f;
			Cursor.visible = true;
			GameObject.Find ("pausePanel").SetActive (true);
			//panel.SetActive (true);
			return(true);    
		}
	}




}
