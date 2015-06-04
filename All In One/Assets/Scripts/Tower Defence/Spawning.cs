using UnityEngine;
using System.Collections;
using System;

public class Spawning : MonoBehaviour {

	float spawnRate;
	float difficulty;
	float waveEnemyCount;
	int   waveEnemy;
	public int   waveCount;
	public bool canSpawn;

	public int   numAlive;	
	public GameObject[] enemies = new GameObject[7] ;

	GameObject enemyType;
	Vector3 spawnLocation;

	float  lastSpawnTime = float.MinValue;
	float  waveStartTime;
	float  waveFinishTime;
	float  waveDelay = 15f;

	
	
	
	// Use this for initialization
	void Start () {

		canSpawn = false;
		
		spawnRate = 2f;
		difficulty = 1;
		waveCount = 1;
		waveEnemyCount = Mathf.Round(difficulty * (int)5);
		numAlive = (int)waveEnemyCount;
		waveStartTime = Time.time;

		spawnLocation = GameObject.Find ("Start").transform.position;

		lastSpawnTime = 0f;
		waveEnemy = UnityEngine.Random.Range (0,enemies.Length);
		enemyType = enemies [waveEnemy];
		
		
		
	}

	// Update is called once per frame
	void Update () {


		if (canSpawn == true) {


			if ((Time.time > lastSpawnTime + spawnRate) && (waveEnemyCount > 0)) {
				
				spawnEnemy ();

			}

			if (numAlive == 0) {

				finishWave ();

			}

			//Should never be less than -1
			if (numAlive < -1) {

				numAlive = -1;
			}


			if ((Time.time > waveFinishTime + waveDelay) && (numAlive == -1)) {

				waveCount += 1;
				waveStartTime = Time.time;
				if (waveCount >= 10) {

					spawnRate = 1.5f;

					if (waveCount >= 20) {
						spawnRate = 1f;
					}

				}

				waveEnemyCount = Mathf.Round (difficulty * (int)10);
				numAlive = (int)waveEnemyCount;

			}
		
	
		}
	
	}



	void spawnEnemy () {

		lastSpawnTime = Time.time;
		Instantiate (enemyType,spawnLocation,Quaternion.identity);
		waveEnemyCount -= 1;

	}

	void finishWave () {


		numAlive = -1;
		waveFinishTime = Time.time;


		difficulty = difficulty + (float)Math.Round (((waveStartTime / waveFinishTime )*100)/100,1);

		waveEnemy = UnityEngine.Random.Range (0,enemies.Length);
		enemyType = enemies [waveEnemy];

	}
}
