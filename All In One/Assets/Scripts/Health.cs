using UnityEngine;
using System.Collections;
using UnityEngine.UI;


	
public class Health : MonoBehaviour {

	public int maxHealth;
	public float currentHealth;
	public GameObject weapon;

	public GameObject character;
	public GameObject control;
	public string characterType;
	public AudioSource tAudio;
	public AudioClip death;
	public Animation die;
	float  healthBarLength;

	

	// Use this for initialization
	void Start () {

		character = this.gameObject;
		characterType = this.gameObject.name;
		getCharacterType ();
		tAudio = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {


	
	}


	void getCharacterType(){



		switch(characterType)
		{
		case "CircleZombie(Clone)":
			maxHealth = 100;

			break;

		case "Player(Clone)":
			maxHealth = 200;
			break;
		
		case "Brute":
			maxHealth = 300;

			break;

		case "CaveWorm":
			maxHealth = 200;

			break;

		case "Golem":
			maxHealth = 500;
			
			break;

		case "Crashed":
			//do nothing
			break;
		default:
			maxHealth = 50;
			break;
		}
		
		currentHealth = maxHealth;
		healthBarLength = currentHealth / maxHealth;

	}


	public void ApplyDamage(float damage,GameObject shooter) {



		currentHealth = currentHealth - damage;
		healthBarLength = currentHealth / maxHealth;

		if (currentHealth <= 0) {
			character.tag = "Dead";
			control = GameObject.FindGameObjectWithTag ("TDControl");

		
			control.GetComponent<Spawning>().numAlive -= 1;
			//tAudio.Play ();
			character.GetComponent<NavMeshAgent>().enabled = false;
			if (die != null)
				character.GetComponent<Animation>().Play (die.name);


			Destroy (this.gameObject,1f);



		}

	}




}
