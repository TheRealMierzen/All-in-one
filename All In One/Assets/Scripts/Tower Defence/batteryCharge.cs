using UnityEngine;
using System.Collections;
using System;

public class batteryCharge : MonoBehaviour {

	public float chargeLevel;
	double lastIncrease;
    public GameObject portal;
	public AudioSource start;
	public AudioSource stop;
    int once;

	// Use this for initialization
	void Start () {
	
		chargeLevel = 0;
		lastIncrease = 0;
        once = 1;
		lastIncrease = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		//30 min
		if(Math.Round (Time.time,0) == lastIncrease + 18 && chargeLevel < 50){
			lastIncrease = Math.Round (Time.time,0);
			if(GameObject.Find ("EndPortal").GetComponent<LifesManager>().lifes  > 0)
				chargeLevel += 1;

		}


		if (chargeLevel == 100 && once == 1 && GameObject.Find("EndPortal").GetComponent<LifesManager>().lifes > 0) {

			once = 0;
            GameObject.Instantiate(portal, new Vector3(-477.7548f, 1007.526f, 375.1212f), Quaternion.identity);
            this.gameObject.GetComponent<ParticleSystem>().enableEmission = false;

		}
	
	}
}
