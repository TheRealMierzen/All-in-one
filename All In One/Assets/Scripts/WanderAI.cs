using UnityEngine;
using System.Collections;

public class WanderAI : MonoBehaviour {

	GameObject character;
	NavMeshAgent agent;
	string action;
	string pAnim;
	float xDest;
	float zDest;
	float stayTime;
	float lastMove;
	float animDelay = 0.2f;
	Animation clip;



	// Use this for initialization
	void Start () {

		character = this.gameObject;
		agent = character.GetComponent<NavMeshAgent> ();
		clip = character.GetComponent<Animation> ();

		action = "Wander";


	}
	
	// Update is called once per frame
	void Update () {


		animationMan ();

		switch(action)
		{
		case "Wander":
			getDestination ();
			clip.Play (pAnim);
			agent.speed = 3.5f;
			break;
		case "Stay":
			clip.Play (pAnim);
			Stay (lastMove,stayTime);

			break;
		case "Crashed":
			//do nothing
			break;
		default:
			//Wander();
			break;
		}
		if ((agent.velocity.sqrMagnitude == 0) && (action != "Stay")) {

			action = "Stay";
			stayTime = Random.Range (5,15);
			lastMove = Time.time;
			//lastMove = Time.time;
			//Stay (lastMove,stayTime);
			
		}
	
	}

	void getDestination (){

		xDest = Random.Range (-10, 10);
		zDest = Random.Range (-10, 10);
		
		
		agent.destination = character.transform.position + new Vector3 (xDest, 0f, zDest);

	}

	void Stay (float time,float waitTime){

		if (Time.time > time + waitTime) {

			action = "Wander";
			getDestination ();

		}

	}

	void animationMan (){

		if (agent.velocity.sqrMagnitude == 0) {

			//if (Time.time == lastMove + animDelay)
				pAnim = character.name + "Idle";

		} else {

			pAnim = character.name + "Walk";
		}

	}
}
