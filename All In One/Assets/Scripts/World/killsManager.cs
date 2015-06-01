using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class killsManager : MonoBehaviour {

	public int kills;
	public Text tKills;

	// Use this for initialization
	void Start () {

		kills = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		tKills.text = "Kills: " + kills;
	
	}


	public void addKill(){

		kills += 1;

	}
}
