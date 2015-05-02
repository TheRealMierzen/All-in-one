using UnityEngine;
using System.Collections;


	
public class Health : MonoBehaviour {

	public int maxHealth;
	public float currentHealth;
	public GameObject weapon;

	public GameObject character;
	public string characterType;
	public AudioSource tAudio;
	public AudioClip death;
	

	// Use this for initialization
	void Start () {

		character = this.gameObject;
		characterType = this.gameObject.name;
		getCharacterTypeType ();
		tAudio = GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () {

	
	
	}


	void getCharacterTypeType(){



		switch(characterType)
		{
		case "CircleZombie(Clone)":
			maxHealth = 100;
			break;
		case "Player(Clone)":
			maxHealth = 200;
			break;
		case "Crashed":
			//do nothing
			break;
		case "Brute":
			maxHealth = 200;
			break;
		default:
			maxHealth = 50;
			break;
		}
		
		currentHealth = maxHealth;

	}


	public void ApplyDamage(float damage,GameObject shooter) {



		currentHealth = currentHealth - damage;

		if (currentHealth <= 0) {


			tAudio.Play ();


			Destroy (this.gameObject,1);

		}

	}


}
