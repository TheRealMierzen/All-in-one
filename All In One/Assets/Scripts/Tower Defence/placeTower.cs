using UnityEngine;
using System.Collections;

public class placeTower : MonoBehaviour {

	public GameObject tower;
	//raycast om te kyk watse blokkie

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit target;

		Debug.DrawLine (transform.position,transform.forward);
		if (tower != null && Input.GetButton ("Fire1")) {




			if (Physics.Raycast (transform.position,transform.forward,out target,10f)){

				if(target.collider.gameObject.GetComponent<blockStatus>().checkStatus () == false){

					Instantiate (tower,target.transform.position + new Vector3(0f,1.3f,0f),Quaternion.identity);
					//target.collider.gameObject.GetComponent<blockStatus>().occupied = true;

				}

			}

		}
	
	}
}
