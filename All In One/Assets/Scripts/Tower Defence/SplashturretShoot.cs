using UnityEngine;
using System.Collections;

public class SplashturretShoot : MonoBehaviour {

	public GameObject Turret;
	public GameObject Target;
	public Vector3 fDirection;
	public Vector3 TurretPos;
	public Vector3 TargetPos;
	public float Distance;
	public string Status;
	public AudioClip ShootingSound;
	public AudioSource tAudio;
	
	float fireRate = 0.5f;
	float range = 15f;
	float lastShotTime = float.MinValue;
	float slowDuration = 5f;
	float TargetMovement;
	public float damage = 10f;
	public float movement = -10f;

	
	
	
	
	// Use this for initialization
	void Start () {
		
		Turret = this.gameObject;
		
		tAudio = GetComponent<AudioSource> ();
		lastShotTime = 0f;
		//TargetMovement = Target.GetComponent<tMovement> ().moveSpeed;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float yRotation;
		
		FindClosestEnemy ();
		
		if (Target != null) {
			
			TurretPos = transform.position;
			TargetPos = Target.transform.position;
			
			fDirection = TurretPos - TargetPos;
			Distance = fDirection.magnitude;
			
			if (Distance <= range && Target != this.gameObject) {
				
				//				if (Turret.transform.forward == fDirection){
				
				transform.LookAt (Target.transform);
				Status = "Shoot";
				//				}else{
				//					TurnToPos ();
				//
				//				}
				
				
			} else {
				
				Status = "Idle";
			}
			
			
		} else {
			
			Status = "Idle";
		}
		
		
		
		switch (Status)
        {
		    case "Idle":
			    Turret.transform.Rotate (Vector3.up, 30 * Time.deltaTime);
			    tAudio.Stop ();
			    break;
		    case "Shoot":
                if (Util.isObstructed(TurretPos,-fDirection,range)==true)
			        Fire();
			    break;
		}
		
		
	}
	
	
	void Fire(){
		float test = lastShotTime + (3F / fireRate);
		
		if (Time.time >  test){
			
			lastShotTime = Time.time;
			tAudio.Play ();
			tAudio.Play ();
			Target.GetComponent<Health>().ApplyDamage (damage,Turret);
			
			if (Target.GetComponent<Health>().currentHealth <=0){
				tAudio.Stop ();
				
				Target = this.gameObject;
				Status = "Idle";
			}
			
			
		}
		
	}
	
	
	void FindClosestEnemy() {
		
		
		GameObject[] enemies;
		float distance = range;
		Vector3 position = transform.position;
		
		enemies = new GameObject[1];
		enemies = GameObject.FindGameObjectsWithTag("TEnemy");
		Target = null;
		
		
		foreach (GameObject enemy in enemies) {
			
			Vector3 diff = position - enemy.transform.position;
			float curDistance = diff.magnitude;
			
			if (curDistance < distance) {
				
				Target = enemy;
				distance = curDistance;
				
			}
			
			
		}
		
		
	}
	
	
	//	void TurnToPos(){
	//		Vector3 v1 = transform.forward;
	//		Vector3 v2 = TargetPos - TurretPos;
	//
	//		Debug.Log (( Mathf.Acos ( (Vector3.Dot(v1,v2)) / (v1.magnitude * v2.magnitude) ) ) * Mathf.Rad2Deg);
	//
	//	}
	
}
