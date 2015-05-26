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


	public int goldWorth;

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
			goldWorth = 100;
			break;

		case "Player(Clone)":
			maxHealth = 200;
			break;
		
		case "Brute":
			maxHealth = 300;
			goldWorth = 30;
			break;

		case "CaveWorm":
			maxHealth = 200;
			goldWorth = 20;
			break;

		case "Golem":
			maxHealth = 500;
			goldWorth = 50;
			break;

		case "DarkDemon":
			maxHealth = 600;
			goldWorth = 50;
			break;

		case "FireDemon":
			maxHealth = 600;
			goldWorth = 50;
			break;

		case "IceDemon":
			maxHealth = 600;
			goldWorth = 50;
			break;

		case "EarthDemon":
			maxHealth = 600;
			goldWorth = 50;
			break;

		case "Goblin":
			maxHealth = 300;
			goldWorth = 50;
			break;

		case "BigGoblin":
			maxHealth = 450;
			goldWorth = 50;
			break;

		case "NormalSkeleton":
			maxHealth = 350;
			goldWorth = 50;
			break;

		case "FastSkeleton":
			maxHealth = 250;
			goldWorth = 50;
			break;

		case "Darkling":
			maxHealth = 600;
			goldWorth = 50;
			break;

		case "BigDarkling":
			maxHealth = 800;
			goldWorth = 50;
			break;

		case "Cyclops":
			maxHealth = 550;
			goldWorth = 50;
			break;

		case "Prowler":
			maxHealth = 600;
			goldWorth = 50;
			break;

		case "GreenGoblin":
			maxHealth = 400;
			goldWorth = 50;
			break;

		case "BlueGoblin":
			maxHealth = 450;
			goldWorth = 50;
			break;

		case "RedGoblin":
			maxHealth = 500;
			goldWorth = 50;
			break;

		case "Spider":
			maxHealth = 100;
			goldWorth = 50;
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

			GameObject.Find ("TD_Control").GetComponent<goldManager>().addGold (goldWorth);
			GameObject.Find ("TD_Control").GetComponent<killsManager>().addKill();

			Destroy (this.gameObject,1f);



		}

	}




}
