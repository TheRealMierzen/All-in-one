using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject player;
	public GameObject level;
	public GameObject spawn;
	// Use this for initialization
	void Start () {
		Instantiate (player, spawn.transform.position, Quaternion.identity);
		Cursor.visible = false;
	}

}
