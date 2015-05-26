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

	GameObject player;
	float fieldofViewDegrees = 90f;
	float range = 2;
	bool playerInSight;

	private SphereCollider col;


	// Use this for initialization
	void Awake () {

		character = this.gameObject;
		agent = character.GetComponent<NavMeshAgent> ();
		clip = character.GetComponent<Animation> ();

		col = gameObject.GetComponent<SphereCollider> ();
		playerInSight = false;
		action = "Wander";
		player = GameObject.FindGameObjectWithTag ("Player");


	}
	
	// Update is called once per frame
	void Update () {

		if (player == null) {

			player = GameObject.FindGameObjectWithTag ("Player");

		}

		if (playerInSight == true) {

			action = "Chase";

		}

		animationMan ();

		switch(action)
		{
		case "Wander":
			getDestination ();
			clip.Play (pAnim);
			agent.speed = 3.5f;
			break;
		case "Chase":
			agent.destination = player.transform.position;
			clip.Play (pAnim);
			chase ();
			break;
		case "Stay":
			clip.Play (pAnim);
			Stay (lastMove,stayTime);

			break;
		case "Sit":
			Debug.Log ("IAMSITTING");
			clip.Play (pAnim);
			Sit (lastMove,stayTime);
			
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
			stayTime = Random.Range (7,20);
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


		if (action == "Chase"){

			pAnim = character.name + "Run";

		}
		if (agent.velocity.sqrMagnitude == 0) {

			if(character.name + "Idle" != null){
				pAnim = character.name + "Idle";
			}

		} else {
			if (character.name + "Sit" != null){

				int sitChance = Random.Range (0,20);
				if (sitChance == 5){
					pAnim = character.name + "Sit";
				}else{
					pAnim = character.name + "Walk";
				}

			}
			pAnim = character.name + "Walk";
		}

	}

	void Sit (float time,float waitTime){
		
		if (Time.time > time + waitTime) {
			
			action = "Wander";
			getDestination ();
			
		}
		
	}

	string chase () {

		if (Vector3.Distance (character.transform.position, player.transform.position) > range) {

			return "Chase";

		} else
			return "Attack";

	}

	void OnTriggerStay(Collider other){

		if (other.gameObject.tag == "Player") {

			playerInSight = false;

			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle (direction, transform.forward);

			if (angle < fieldofViewDegrees * 0.5f) {

				RaycastHit hit;

				if (Physics.Raycast (transform.position + transform.up, direction.normalized, out hit, col.radius)) {

					if (hit.collider.gameObject.tag == "Player") {
						Debug.Log (hit.collider.gameObject.name);
						playerInSight = true;

					}

				}

			}
		} else
			playerInSight = false;

	}

	void OnTriggerExit(Collider other){

		if (other.gameObject == player) {

			playerInSight = false;

		}

	}
}
