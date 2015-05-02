using UnityEngine;
using System.Collections;

public class Wandering : MonoBehaviour {
	

	public Transform Player;
	public Vector3 Direction;
	public Vector3 EnemyPos;
	public Vector3 PlayerPos;
	public RaycastHit HitInfo;
	public float Distance;
	public int moveSpeed;


	public string currentState;
	public float rayLength;


	// Use this for initialization
	void Start () {


		moveSpeed = 12;

		rayLength = 10F;
		
		currentState = "Wander";
		

		
	}
	
	// Update is called once per frame
	void Update () {

		//Move na function
		Player = GameObject.FindWithTag("Player").transform;

		EnemyPos = transform.position;
		PlayerPos = Player.transform.position;
		
		Direction = PlayerPos - EnemyPos;
		Distance = Direction.magnitude;
		
		Direction.Normalize();

		
		stateCheck();
		
		switch(currentState)
		{
		case "Chase":
			Chase();
			break;
		case "Crashed":
			//do nothing
			break;
		default:
			Wander();
			break;
		}

	
	}


	void stateCheck()
	{
		//Check if enemy should chase the player
		RaycastHit HitInfo;
		Ray playerRay = new Ray (transform.position, Direction);
		
		Debug.DrawRay (transform.position, Direction * rayLength);
		
		if (Physics.Raycast (playerRay, out HitInfo, rayLength)) {
			//Vector3.Angle(transform.forward.normalized,Player.forward.normalized)
			
			if ((HitInfo.collider.tag == "Player(Clone)") && Distance <= 8) {

				currentState = "Chase";
				
			} else {
				
				currentState = "Wander";
				
			}
		}
	}


	void Chase()
	{
		
		transform.Translate(Direction * moveSpeed * Time.deltaTime, Space.World);
		if (Distance < 0.1)
		{
			Player.GetComponent<Rigidbody>().AddForce (Player.up* 20);
			
		}
		
	}


	void Wander()
	{

		int idleTime = Random.Range(5, 20);
		//int walkTime = Random.Range(2,8);
		int rotateTime = Random.Range (0, 5);

		idleTime = 20;
		transform.Rotate(Vector3.up* rotateTime * 20 * Time.deltaTime); 
		Wait (idleTime);
		 //(new Vector3 (x, RandomGenerate.GroundLevel, z));



		transform.Translate (transform.forward * moveSpeed * Time.deltaTime,Space.World );


	}


	void Wait(int idleTime){
		
		WaitStep2 (idleTime);
		
		
	}


	IEnumerator WaitStep2(int idleTime){

		yield return new WaitForSeconds (idleTime);


	}



}
