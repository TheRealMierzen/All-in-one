using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	public RaycastHit HitInfo;
	public RaycastHit pHitInfo;

	public float rayLength;
	public GameObject item;
	public GameObject player;
	public bool floatingUp;



	// Use this for initialization
	void Start () {


		player = GameObject.FindGameObjectWithTag ("Player");

		float xScale = 0.2f;
		float yScale = 0.2f;
		float zScale = 0.2f;

		float OxScale = 0.2f;
		float OyScale = 0.2f;
		float OzScale = 0.2f;

		item = gameObject;


		OxScale = item.transform.localScale.x;
		OyScale = item.transform.localScale.y;
		OzScale = item.transform.localScale.z;

		//Scale object down
		OxScale = OxScale * xScale; 
		OyScale = OyScale * yScale; 
		OzScale = OzScale * zScale; 

		item.transform.localScale = new Vector3(OxScale , OyScale , OzScale );



	}
	
	// Update is called once per frame
	void Update () {

		//transform.LookAt(player.transform);
		Float ();

		Vector3 pDirection = player.transform.position - item.transform.position;

		pDirection.Normalize ();
		float distance = (transform.localPosition  - player.transform.position).magnitude;//Vector3.Distance (transform.localPosition,player.transform.localPosition );
	

		if (distance <= 1f) {

			if (Inventory.addToInv(this.gameObject.name) == true){

					Destroy (this.gameObject);

			}

			UnityEditor.EditorApplication.Beep ();

		}
		


	}



	void Float(){



		Vector3 temp;
		
		
		
		item.transform.Rotate (Vector3.up, 20 * Time.deltaTime);

		Ray itemRay = new Ray (transform.position, Vector3.down);
		
		
		Debug.DrawRay (transform.position, Vector3.down);


		
		if (Physics.Raycast (itemRay, out HitInfo)) {
			
			
			if (HitInfo.collider.tag == "Ground") {
				

				temp = new Vector3 (transform.position.x,HitInfo.transform.position.y + 1f, transform.position.z);
				transform.position = temp;
				
			}
		}

	}



}
