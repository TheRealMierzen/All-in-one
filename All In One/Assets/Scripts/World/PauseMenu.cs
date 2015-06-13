using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public static GameObject PauseScreen;
	public static GameObject UI;
	public static bool paused = false;
	public GameObject player;


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
		player = GameObject.Find ("Player(Clone)");

		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			player.GetComponent<MouseLook>().enabled = true;
            player.GetComponentInChildren<MouseLook>().enabled = true;
            player.GetComponentInChildren<placeTower>().enabled = true;
            Cursor.visible = false;
			PauseScreen.GetComponent<Canvas>().enabled = false;
			UI.SetActive (true);
			paused = false;
		}
		else
		{
			Time.timeScale = 0f;
			player.GetComponent<MouseLook>().enabled = false;
            player.GetComponentInChildren<MouseLook>().enabled = false;
            player.GetComponentInChildren<placeTower>().enabled = false;
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

    public void Retry()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevelName);
        Time.timeScale = 1f;
    }

}
