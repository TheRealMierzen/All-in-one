using UnityEngine;
using System.Collections;




public class Spawn : MonoBehaviour {

	float spawnRate;
	float totalHealth;
	int   difficulty;
	int   waveEnemy;

	string[] enemies = new string[] {"Brute","CaveWorm","Golem","Robot"};
	string enemyType;



	// Use this for initialization
	void Start () {


		spawnRate = 2f;
		difficulty = 1;

		waveEnemy = Random.Range (-1,enemies.Length);


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
