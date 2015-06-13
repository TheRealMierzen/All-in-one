using UnityEngine;
using System.Collections;

public class LongRangeShoot : MonoBehaviour {

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
	float range = 20f;
	public float damage = 100f;
	float lastShotTime = float.MinValue;
	LineRenderer line;
	public GameObject GunTip;
	public GameObject hitLight;
	string turretType   = "Electric";
    float rotationSpeed = 30f;


    // Use this for initialization
    void Start () {

		Turret = this.gameObject;

		tAudio = GetComponent<AudioSource> ();
		lastShotTime = 0f;

		line = gameObject.GetComponentInChildren<LineRenderer>();
		line.enabled = false;


		
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
				
				
				transform.LookAt (Target.transform);
				Status = "Shoot";
				
			} else {
				Status = "Idle";
			}
			
			
		} else {
			Status = "Idle";
		}


		switch (Status)
        {
		    case "Idle":
			    line.enabled = false;
                if (gameObject.transform.rotation.z != 0)
                {
                    float yRotation = gameObject.transform.localEulerAngles.y;
                    float zRotation = gameObject.transform.localEulerAngles.z;
                    //gameObject.transform.rotation = Quaternion.Euler(0f, yRotation, zRotation);
                    transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.Euler(0f, yRotation, zRotation), Time.time * rotationSpeed / 2);
                }
                Turret.transform.Rotate (Vector3.up, 30 * Time.deltaTime);
			    tAudio.Stop ();
			    break;
		    case "Shoot":
                if (Util.isObstructed(TurretPos, fDirection, range) == false)
                {
                    FireLaser();
                    line.enabled = true;
                    Fire();
                }
                break;
		}
	

	}


 	void Fire(){
		float test = lastShotTime + (3F / fireRate);

		if (Time.time >  test){

			lastShotTime = Time.time;
			StopCoroutine("FireLaser");
			StartCoroutine("FireLaser");
			tAudio.Play ();
			Target.GetComponent<Health>().ApplyDamage (damage,Turret,turretType);

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



		foreach (GameObject enemy in enemies) {

			Vector3 diff = position - enemy.transform.position;
			float curDistance = diff.magnitude;

			if (curDistance < distance && enemy.tag != "Dead") {

				Target = enemy;
				distance = curDistance;

			}


		}


	}


	IEnumerator FireLaser(){
		line.useWorldSpace = true;
		line.SetVertexCount (2);
		Ray ray = new Ray(GunTip.transform.position, fDirection);
		RaycastHit hit;


		Physics.Raycast(ray, out hit, Distance);
		
		Vector3 hitpoint = hit.point;
		line.SetPosition(0, GunTip.transform.position);
		line.SetPosition(1, Target.transform.position + new Vector3(0f,1.5f,0f));
			
		

		hitLight.transform.position = Target.transform.position + new Vector3 (0f, 1.5f, 0f);


								
		yield return null;
		
		
	}

}

