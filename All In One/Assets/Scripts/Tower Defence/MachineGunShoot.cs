using UnityEngine;
using System.Collections;


public class MachineGunShoot : MonoBehaviour {

	public GameObject Turret;
	public GameObject Target;
	public Vector3 fDirection;
	public Vector3 TurretPos;
	public Vector3 TargetPos;
	public float Distance;
	public string Status;
	public AudioClip ShootingSound;
	public AudioSource tAudio;
	
	float fireRate = 3f;
	float range = 10f;
	float rotationSpeed = 30f;
	public float damage = 20f;
	float lastShotTime = float.MinValue;
	
	
	
	
	// Use this for initialization
	void Start () {
		
		Turret = this.gameObject;
		
		tAudio = GetComponent<AudioSource> ();
		lastShotTime = 0f;
		
		
	}
	
	// Update is called once per frame
	void Update () {

		
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
//				}

			
			} else {
				TurnToPos();
				Status = "Idle";
			}


		} else {

			Status = "Idle";
		}


		
		switch (Status)
        {
            case "Idle":
                Turret.transform.Rotate (Vector3.up, rotationSpeed * Time.deltaTime);
			    tAudio.Stop ();
			    break;

            case "Shoot":
                if (Util.isObstructed(TurretPos,-fDirection,range) == true)
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


	void TurnToPos(){


		float yRotation = transform.rotation.y;
		Vector3 newRotation = new Vector3(0f,yRotation,0f);

		transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler ( 0f,yRotation,0f) , Time.time * rotationSpeed);
		//Debug.Log (( Mathf.Acos ( (Vector3.Dot(v1,v2)) / (v1.magnitude * v2.magnitude) ) ) * Mathf.Rad2Deg);

	}
	
}

