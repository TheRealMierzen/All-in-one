using UnityEngine;
using System.Collections;




public class RandomGenerate : MonoBehaviour {

	public static int GroundLevel;


	public GameObject Shin;
	public GameObject Frenemy;
	public GameObject Stone;
	public GameObject Dirt;
	public GameObject Grass;
	public GameObject PPortal;
	public GameObject MCPortal;
	public GameObject Player;
	public GameObject PortalGround;
	public GameObject Marker;
	public GameObject TreeTrunk;
	public GameObject Leaves;
	public GameObject Iron;

	public GameObject Enemy;
	public GameObject DOENDIT;
	public GameObject Coal;



	public Vector3 MCLevel;


	// Use this for initialization
	void Start () {


		GroundLevel = Random.Range (10, 12);
		MCLevel = new Vector3 (100, GroundLevel, 0);



		for (int a = -10; a <= 11; a++) {
			for (int b = 1; b <= GroundLevel; b++) {
				for (int c = -10; c <= 11; c++) {
					int Type = Random.Range (1, 3);
					int TreeChance = Random.Range (1, 50);
							
					if (b == GroundLevel) {
						Type = 0;
					}
						

					if (b == GroundLevel && TreeChance % 25 == 0) {
						int TreeParts;
						TreeParts = Random.Range (4, 8);

						for (int SpawningPart = 1; SpawningPart <= TreeParts; SpawningPart++) {
								
							Instantiate (TreeTrunk, new Vector3 (a, b + SpawningPart, c), Quaternion.identity);

						}
							

					}

					if (Type == 0) {
						Instantiate (Grass, new Vector3 (a, b, c), Quaternion.identity);
					}


					if (Type == 1) {
						Instantiate (Dirt, new Vector3 (a, b, c), Quaternion.identity);
					}
						
					if (Type == 2) {

						Type = Random.Range (1, 100);
							
						if (Type % 50 == 0) {

							Instantiate (Iron, new Vector3 (a, b, c), Quaternion.identity);
						}
							
						if (Type % 20 == 0) {

							Instantiate (Coal, new Vector3 (a, b, c), Quaternion.identity);

						} else 
							Instantiate (Stone, new Vector3 (a, b, c), Quaternion.identity);
							
					}
							
							
				}
			
			}
		}

		SpawnEnemies ();



		Instantiate (PPortal, new Vector3 (2, 11, 4), Quaternion.identity);
		Instantiate (PPortal, new Vector3 (2, 12, 4), Quaternion.identity);
		Instantiate (PPortal, new Vector3 (2, 13, 4), Quaternion.identity);
		Instantiate (PPortal, new Vector3 (2, 14, 4), Quaternion.identity);
		Instantiate (PPortal, new Vector3 (2, 15, 4), Quaternion.identity);

		Instantiate (PPortal, new Vector3 (2, 11, 8), Quaternion.identity);
		Instantiate (PPortal, new Vector3 (2, 12, 8), Quaternion.identity);
		Instantiate (PPortal, new Vector3 (2, 13, 8), Quaternion.identity);
		Instantiate (PPortal, new Vector3 (2, 14, 8), Quaternion.identity);
		Instantiate (PPortal, new Vector3 (2, 15, 8), Quaternion.identity);

		Instantiate (PPortal, new Vector3 (2, 15, 7), Quaternion.identity);
		Instantiate (PPortal, new Vector3 (2, 15, 6), Quaternion.identity);
		Instantiate (PPortal, new Vector3 (2, 15, 5), Quaternion.identity);

		Instantiate (MCPortal, new Vector3 (2, 12, 6), Quaternion.identity);
		Instantiate (PortalGround, new Vector3 (0, GroundLevel, 0), Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {


	}


	void SpawnEnemies() {

		int NumEnemies = Random.Range (0,100);

		if (NumEnemies%10 == 0){

			Instantiate (Enemy,new Vector3 (1,GroundLevel + 1,1), Quaternion.identity);


		}


	}
}	
