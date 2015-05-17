using UnityEngine;
using System.Collections;
using System;

public class EnemyAI : MonoBehaviour
{
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
	public float rayLength;




    // Use this for initialization
    void Start()
    {
        moveSpeed = 10;
        minfollowDist = 15;
        maxFollowDist = 20;
		rayLength = 16F;

		currentState = "Circle";

        
    }

    // Update is called once per frame
    void Update()
    {
		//Move na function
		Player = GameObject.FindWithTag("Player").transform;

        EnemyPos = transform.position;
        //EnemyPos.y = 0;
        PlayerPos = Player.transform.position;
        //PlayerPos.y = 0;

        Direction = PlayerPos - EnemyPos;
        Distance = Direction.magnitude;

        Direction.Normalize();

        velocityMagnitude = transform.GetComponent<Rigidbody>().velocity.magnitude;
        
        transform.LookAt(Player);

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
                Circle();
                break;
        }
}


    void stateCheck()
    {


        //Check if enemy should chase the player
        RaycastHit HitInfo;
        Ray playerRay = new Ray(transform.position, Direction);

        Debug.DrawRay(transform.position, Direction * rayLength);

        if (Physics.Raycast(playerRay, out HitInfo, rayLength))
		{
			//Vector3.Angle(transform.forward.normalized,Player.forward.normalized)

			if ((HitInfo.collider.tag == "Player") && ((Math.Round(Player.transform.forward.normalized.x,7) == Math.Round(transform.forward.normalized.x,7)) && (Math.Round(Player.transform.forward.normalized.z,7) == Math.Round(transform.forward.normalized.z,7)))) {
				Debug.Log ("CAN CHASE");

				int chanceToChase = 25;

				if (randomBool (chanceToChase) == true) {
					currentState = "Chase";

//					if(Distance <= 1.5) { //attack sound
//
//						audio.Play();
//
//					}
				}

			} else {

				currentState = "Circle";

				}
		}
    }

    void Circle()
	{

		transform.RotateAround(PlayerPos, Vector3.up, moveSpeed * Time.deltaTime);
        if (Distance < minfollowDist)
        {

            Vector3 tempDirection = Direction;
            Vector3 waarGaanEnemyWees;
            float newDistance;
            waarGaanEnemyWees = EnemyPos + (tempDirection * moveSpeed * Time.deltaTime);
           
            newDistance = (PlayerPos - waarGaanEnemyWees).magnitude;

            if (newDistance < Distance)
            {  //dan gaan hy in die verkeerde kant gaan

                tempDirection = -Direction;

            }

            transform.Translate(tempDirection * moveSpeed * Time.deltaTime, Space.World);

        }
        else
        {
            if (Distance > maxFollowDist)
            {
                Vector3 tempDirection = Direction;
                Vector3 waarGaanEnemyWees;
                float newDistance;
                waarGaanEnemyWees = EnemyPos + (tempDirection * moveSpeed * Time.deltaTime);
               
                newDistance = (PlayerPos - waarGaanEnemyWees).magnitude;

                if (newDistance > Distance)
                {  //dan gaan hy in die verkeerde kant gaan

                    tempDirection = -Direction;

                }

                transform.Translate(tempDirection * moveSpeed * Time.deltaTime, Space.World);

            }
            else
            {

                transform.RotateAround(PlayerPos, Vector3.up, moveSpeed * Time.deltaTime);

            }


        }
    }

    void Chase()
    {
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
        //transform.Translate(Direction * moveSpeed * Time.deltaTime, Space.World);
        if (Distance < 0.1)
        {
			Player.GetComponent<Rigidbody>().AddForce (Player.up* 20);

        }

    }

    void MoveAround()
    {

        float angle = 0.5f; //of 30

        transform.Rotate(Vector3.up, angle);

        //transform.RotateAround (PlayerPos, Vector3.up, moveSpeed * Time.deltaTime);

        if (velocityMagnitude < 4)
        {

            transform.Rotate(Vector3.up, angle);

        }
        else
        {

            transform.Rotate(Vector3.up, -angle);

        }

        transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);

    }

	/// <summary>
	/// Returns a boolean value with a certain percent chance of being true.
	/// </summary>
	/// <returns><c>true</c>, if bool was randomed, <c>false</c> otherwise.</returns>
	/// <param name="percentChanceOfHappening">Percent chance of begin true.</param>
    bool randomBool(int percentChanceOfHappening)
    {
        if (UnityEngine.Random.Range(0, 100) <= percentChanceOfHappening)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}