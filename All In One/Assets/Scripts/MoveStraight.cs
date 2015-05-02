using UnityEngine;
using System.Collections;

public class MoveStraight : MonoBehaviour {

	//public Transform Target;
	public Transform Player;
	public Vector3 Direction;
	public Vector3 EnemyPos;
	public Vector3 PlayerPos;
	public RaycastHit HitInfo;
	public float Distance;
	public int moveSpeed;
	public int minfollowDist;
	public int maxFollowDist;
	public float velocityMagnitude;
	public string currentState;


	// Use this for initialization
	void Start () {
		moveSpeed = 10;
		minfollowDist = 15;
		maxFollowDist = 20;
		currentState = "Circle";

		Player = GameObject.FindWithTag("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		EnemyPos = transform.position;
		//EnemyPos.y = 0;
		PlayerPos = Player.transform.position;
		//PlayerPos.y = 0;

		Direction = PlayerPos - EnemyPos;
		Distance = Direction.magnitude;

		Direction.Normalize ();

		velocityMagnitude = transform.GetComponent<Rigidbody>().velocity.magnitude;




		transform.LookAt (Player);


		if (currentState == "Circle") {

			if (Distance < minfollowDist) {

				Vector3 tempDirection = Direction;
				Vector3 waarGaanEnemyWees;
				float newDistance;
				waarGaanEnemyWees = EnemyPos + (tempDirection * moveSpeed * Time.deltaTime);


				newDistance = (PlayerPos - waarGaanEnemyWees).magnitude;

				if (newDistance < Distance) {  //dan gaan hy in die verkeerde kant gaan
				
					tempDirection = -Direction;

				}

				transform.Translate (tempDirection * moveSpeed * Time.deltaTime, Space.World);

			} else {

				if (Distance > maxFollowDist) {
					
					Vector3 tempDirection = Direction;
					Vector3 waarGaanEnemyWees;
					float newDistance;
					waarGaanEnemyWees = EnemyPos + (tempDirection * moveSpeed * Time.deltaTime);


					newDistance = (PlayerPos - waarGaanEnemyWees).magnitude;
					
					if (newDistance > Distance) {  //dan gaan hy in die verkeerde kant gaan
						
						tempDirection = -Direction;

					}

					transform.Translate (tempDirection * moveSpeed * Time.deltaTime, Space.World);

				} else {
					
					transform.RotateAround (PlayerPos, Vector3.up, moveSpeed * Time.deltaTime);

				}


			}

		} else {//if circle end

			if (currentState == "Chase"){

				Chase();

			}

		}

		vState ();

}


	void MoveAround(){

		float angle = 0.5f; //of 30

		transform.Rotate(Vector3.up,angle);

		//transform.RotateAround (PlayerPos, Vector3.up, moveSpeed * Time.deltaTime);

		if (velocityMagnitude < 4) {

			transform.Rotate (Vector3.up, angle);

		}else{

			transform.Rotate (Vector3.up, -angle);

		}

		transform.Translate (transform.forward * moveSpeed * Time.deltaTime, Space.World);

}



	void  vState (){

		RaycastHit HitInfo;
		Ray playerRay = new Ray (transform.position, Direction);

		//return "Chase"; 

		Debug.DrawRay (transform.position, Direction * 10F);
		Physics.Raycast(playerRay,out HitInfo,10f);
		
		//if ((HitInfo.collider.tag == "Player") && (transform.forward == Player.forward)){

			int Chase = Random.Range (0,50);

			if (Chase%25 == 0){
					
				currentState = "Chase";


			}else{

				currentState  = "Circle";
			}


		//}else{
			
			currentState  = "Circle";

		//}
		//throw new System.InvalidOperationException ();

}


	void Chase () {

		transform.Translate (Direction * moveSpeed * Time.deltaTime, Space.World);
		if (Distance < 0.1) {

			//Player.rigidbody.AddForce (-Player.forward* 20);

		}

}











}