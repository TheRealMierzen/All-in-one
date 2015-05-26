using UnityEngine;
using System.Collections;

public class blockStatus : MonoBehaviour {

	//Check if object is above block, if not block is unoccupied, if unoccupied can spawn tower
	public bool checkStatus () {

		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.up, out hit, 1.5f)){
			//if nothing
			if (hit.collider.gameObject == null) {

				return false;

			}

			return true;
			
	
		}
		return false;
	
	}
}