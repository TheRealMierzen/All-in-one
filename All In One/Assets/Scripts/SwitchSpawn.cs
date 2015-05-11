using UnityEngine;
using System.Collections;

public class SwitchSpawn : MonoBehaviour {

	public GameObject player;
	public string 	  spawn;
	public Vector3 	  spawnLocation;


	// Use this for initialization
	void Start () {
	
		SetSpawn (spawn);

	}
	
	public void SetSpawn(string spawn){

		switch (spawn) {
		case "Tower":

			spawnLocation = new Vector3 (1.370239f, 1003.83f, 1029.626f);
			break;
		case "Zombie":

			spawnLocation = new Vector3 (1015, 1001, 0);
			break;
		case "Crashed":
			//do nothing
			break;
		
			
			
		}

		player.transform.position = spawnLocation;

	}


	public void spawnPlayer(){


		if (GameObject.FindGameObjectWithTag ("Player")) {
			Destroy (GameObject.FindGameObjectWithTag ("Player"));

		}
		Instantiate (player,spawnLocation,Quaternion.identity);

	}
}
