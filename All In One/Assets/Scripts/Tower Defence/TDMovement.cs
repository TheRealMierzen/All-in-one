using UnityEngine;
using System.Collections;

public class TDMovement : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

		GameObject end = GameObject.Find("End");
		if (end)
			GetComponent<NavMeshAgent>().destination = end.transform.position;
	
	}

	void Update() {
		// If endPortal then lifes -1 & destroy

		if (Vector3.Distance (this.gameObject.transform.position,GetComponent<NavMeshAgent>().destination) < 1f) {
			GameObject.Find ("EndPortal").GetComponent<LifesManager>().decrease();
			GameObject.Find ("TD_Control").GetComponent<Spawning>().numAlive -= 1;
			Destroy (this.gameObject);
		}

	}

}
