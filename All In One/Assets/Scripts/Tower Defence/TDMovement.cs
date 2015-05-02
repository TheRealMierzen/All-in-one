using UnityEngine;
using System.Collections;

public class TDMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject end = GameObject.Find("End");
		if (end)
			GetComponent<NavMeshAgent>().destination = end.transform.position;
	
	}
	

}
