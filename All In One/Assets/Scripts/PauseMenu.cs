using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public static bool paused = false;
	public static GameObject pausePanel;


	void Start (){

		pausePanel = GameObject.Find ("pausePanel");
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
		if(Time.timeScale == 0f)
		{
			Debug.Log ("unpause");
			Time.timeScale = 1f;
			Cursor.visible = false;
//			GameObject.Find ("pausePanel").SetActive (false);
			pausePanel.SetActive (false);
			return(false);
		}
		else
		{
			Debug.Log ("pause");
			Time.timeScale = 0f;
			Cursor.visible = true;
//			GameObject.Find ("pausePanel").SetActive (true);
			pausePanel.SetActive (true);
			return(true);    
		}
	}




}
