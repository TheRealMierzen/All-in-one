using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	static string[] pInventory 	   = new string[10];
	public static int[] 	countInventory = new int[10];
	public static string[] emptyInventory = new string[10];


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public static bool addToInv(string item){
		bool flag = false;
		
		
		for (int i = 0; i < pInventory.Length -1 ; i++) {
			//Check if item is in inventory
			if (pInventory[i] == item){
				
				countInventory[i] += 1;
				flag = true;
				Debug.Log ("Added " + item + " to inventory");
				return true;
				
			}else if((pInventory[i] == "") || pInventory[i] == null)  {
				
				emptyInventory[i] = "Empty";
				
			}
			
		}


		//If not in inventory, find empty spot
		if (flag == false) {
			
			for (int e = 0; e < emptyInventory.Length -1; e++) {
				
				if (emptyInventory [e] == "Empty") {
					
					pInventory [e] = item;
					countInventory [e] = 1;
					emptyInventory [e] = "";
					flag = true;
					Debug.Log ("Added " + item + " to inventory");
					return true;
					
				} 
				
			}
	
		} else {

			return false;

		}


		return false;
		
		
	}


}
