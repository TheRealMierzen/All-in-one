using UnityEngine;
using System.Collections;

public class goldValue : MonoBehaviour {

	public int value;
	public GameObject gold;

	void start (){

		value = this.gameObject.GetComponent<Health> ().goldWorth;

		Instantiate (gold, this.gameObject.transform.position, Quaternion.identity);


	}

		

}
