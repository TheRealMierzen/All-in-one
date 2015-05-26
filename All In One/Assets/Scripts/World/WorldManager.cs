using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {

	public float startDelay;
	public float startTime;
	public GameObject startPortal;
	public GameObject endPortal;

	void Awake(){

		if (Application.loadedLevelName != "TD") {

			Application.LoadLevel ("TD");

		}

		startPortal.GetComponent<EllipsoidParticleEmitter>().emit = false;
		endPortal.GetComponent<EllipsoidParticleEmitter>().emit = false;

		startDelay = 30f;
		startTime = Time.time;

	}
	// Use this for initialization
	void  Update () {


		int once = 1;
		if (Application.loadedLevelName == "TD" && once == 1) {


			if(Time.time >= startDelay - 3){

				startPortal.GetComponent<EllipsoidParticleEmitter>().emit = true;
				endPortal.GetComponent<EllipsoidParticleEmitter>().emit = true;
					
			}

			if(Time.time > startTime + startDelay ){

				GameObject.Find ("TD_Control").GetComponent<Spawning>().canSpawn = true ;

				once += 1;

				this.gameObject.GetComponent<WorldManager>().enabled = false;	

			}

		}
	
	}
	

}
