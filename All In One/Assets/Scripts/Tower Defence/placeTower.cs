using UnityEngine;
using System.Collections;

public class placeTower : MonoBehaviour {

	GameObject tower;
	public GameObject[] Towers = new GameObject[6]; 
	int[]  towerCost = new int[6];
	int    selectedTower;

	// Use this for initialization
	void Awake () {

		towerCost[0] = 30;
		towerCost[1] = 35;
		towerCost[2] = 50;
		towerCost[3] = 80;
		towerCost[4] = 110;
		towerCost[5] = 100;

		selectedTower = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (tower != Towers [selectedTower]) {
			tower = Towers[selectedTower];
		}

		Debug.Log (Towers[selectedTower].name);

		if (Input.GetKeyUp (KeyCode.Alpha1)) {

			selectedTower = 0;

		}
		if (Input.GetKeyUp (KeyCode.Alpha2)) {
			
			selectedTower = 1;
			
		}
		if (Input.GetKeyUp (KeyCode.Alpha3)) {
			
			selectedTower = 2;
			
		}
		if (Input.GetKeyUp (KeyCode.Alpha4)) {
			
			selectedTower = 3;
			
		}
		if (Input.GetKeyUp (KeyCode.Alpha5)) {
			
			selectedTower = 4;
			
		}
		if (Input.GetKeyUp (KeyCode.Alpha6)) {
			
			selectedTower = 5;
			
		}


		//Raycast to see on which block the tower must be placed
		if (tower != null && Input.GetButton ("Fire1")) {

			RaycastHit target;

			if (Physics.Raycast (transform.position,transform.forward,out target,10f)){

				if(target.collider.gameObject.GetComponent<blockStatus>().checkStatus () == false){

					Instantiate (tower,target.transform.position + new Vector3(0f,1.3f,0f),Quaternion.identity);

				}

			}

		}
	
	}


}
