using UnityEngine;
using System.Collections;

public class TDMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject end = GameObject.Find("End");
		if (end)
			GetComponent<NavMeshAgent>().destination = end.transform.position;
	
	}

	void OnTriggerEnter(Collider collision) {
		// If endPortal then lifes -1 & destroy

		Debug.Log (collision.name);
		if (collision.name == "EndPortal") {
			collision.GetComponent<LifesManager>().decrease();
			Destroy (this.gameObject);
		}
	}

}
