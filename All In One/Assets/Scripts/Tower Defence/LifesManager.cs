using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifesManager : MonoBehaviour {

	public int lifes;
	public Text tLifes;

	// Use this for initialization
	void Start () {

		lifes = 20;
	
	}
	
	// Update is called once per frame
	void Update () {

		tLifes.text = "Lifes: " + lifes;
	
	}


	public void decrease() {

		lifes -= 1;

	}
}
