using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class goldManager : MonoBehaviour {

	public int gold;
	public Text tGold;
	
	// Use this for initialization
	void Start () {
		
		gold = 100;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		tGold.text = "Gold: " + gold;
		
	}
	
	
	public void addGold(int ammount){
		
		
		gold += ammount;
		
	}
}
