using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject player;
	public GameObject level;
	public GameObject spawn;
	// Use this for initialization
	void Start () {

//		if (level.name == "Level1") {
//
//			Spawn = GameObject.Find ("SpawnSpot1");
//		}
		Instantiate (player, spawn.transform.position, Quaternion.identity);
		Cursor.visible = false;
	}

}
