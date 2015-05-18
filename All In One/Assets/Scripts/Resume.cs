using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {

	// Use this for initialization
	void onMouseDown(){

		if(PauseMenu.paused)
		{
				PauseMenu.paused = PauseMenu.togglePause();
		}

	}
}
