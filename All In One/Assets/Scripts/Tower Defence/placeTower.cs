using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class placeTower : MonoBehaviour {

	GameObject tower;
	public GameObject[] Towers = new GameObject[6]; 
	int[]  towerCost = new int[6];
	int    selectedTower;
//	Sprite image;
//	public Image  show;
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
		//Get texture of turret and appply it to button
//		image = Sprite.Create (AssetPreview.GetAssetPreview (tower),new Rect (-409,-282,AssetPreview.GetAssetPreview (tower).width,AssetPreview.GetAssetPreview (tower).height),new Vector2(0,0));
//		show.GetComponent<Image>().sprite  = image;


		//Raycast to see on which block the tower should be placed
		if (tower != null && Input.GetButton ("Fire1")) {

			RaycastHit target;

			if (Physics.Raycast (transform.position,transform.forward,out target,7f)){

				if(target.collider.gameObject.GetComponent<blockStatus>().checkStatus () == false && GameObject.Find("TD_Control").GetComponent<goldManager>().gold >= towerCost[selectedTower]){

					Instantiate (tower,target.transform.position + new Vector3(0f,1.3f,0f),Quaternion.identity);
					GameObject.Find("TD_Control").GetComponent<goldManager>().gold -= towerCost[selectedTower];

				}

			}

		}
	
	}


}
