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
        if (Math.Round (Time.time,0) == Math.Round(lastIncrease,0) + 18 && chargeLevel < 100){
			lastIncrease = Math.Round (Time.time,0);
			if(GameObject.Find ("EndPortal").GetComponent<LifesManager>().lifes  > 0)
				chargeLevel += 1;         
        }


		if (chargeLevel == 100 && once == 1 && GameObject.Find("EndPortal").GetComponent<LifesManager>().lifes > 0 && portal != null) {

			once = 0;
            Instantiate(portal, new Vector3(-477.7548f, 1007.526f, 375.1212f), Quaternion.identity);
            gameObject.GetComponent<ParticleSystem>().enableEmission = false;

        }


        if(chargeLevel == 100 && portal == null && once == 1)
        {
            once = 2;
            gameObject.GetComponent<ParticleSystem>().enableEmission = false;

        }
	
	}
}
