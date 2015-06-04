using UnityEngine;
using System.Collections;

public class flockLeader : MonoBehaviour {

	public GameObject[] flock = new GameObject[10];

	// Use this for initialization
	void Start () {

		Debug.Log ("IAMTHELEADER: " + this.gameObject.GetInstanceID ());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void generateFlock(params int[] group){


		flock [0] = this.gameObject;

		for (int i = 1; i <= group.Length; i++) {

			flock[i] = GameObject.Find (group[i].ToString ());

		}

	}
}
