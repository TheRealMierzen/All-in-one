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
	ParticleSystem fade;

	public int goldWorth;
	string Type;

	// Use this for initialization
	void Start () {

		character = this.gameObject;
		characterType = this.gameObject.name;
		getCharacterType ();
		tAudio = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

//
//		if (currentHealth <= 0 && characterType != "Player(Clone)") {
//
//			GameObject.Find ("TD_Control").GetComponent<goldManager>().addGold (goldWorth);
//			GameObject.Find ("TD_Control").GetComponent<killsManager>().addKill();
//
//			character.GetComponent<NavMeshAgent>().enabled = false;
//			if (die != null)
//				character.GetComponent<Animation>().Play (die.name);
//
//			Destroy (character, 1f);
//
//		}

	
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
		
		case "Brute(Clone)":
			maxHealth = 300;
			goldWorth = 30;
			Type = "Normal";
			break;

		case "CaveWorm(Clone)":
			maxHealth = 200;
			goldWorth = 20;
			Type = "Normal";
			break;

		case "Golem(Clone)":
			maxHealth = 500;
			goldWorth = 50;
			Type = "Ice";
			break;

		case "DarkDemon(Clone)":
			maxHealth = 600;
			goldWorth = 50;
			Type = "Dark";
			break;

		case "FireDemon(Clone)":
			maxHealth = 600;
			goldWorth = 50;
			Type = "Fire";
			break;

		case "IceDemon(Clone)":
			maxHealth = 600;
			goldWorth = 50;
			Type = "Ice";
			break;

		case "EarthDemon(Clone)":
			maxHealth = 600;
			goldWorth = 50;
			Type = "Nature";
			break;

		case "Goblin(Clone)":
			maxHealth = 300;
			goldWorth = 50;
			Type = "Normal";
			break;

		case "BigGoblin(Clone)":
			maxHealth = 450;
			goldWorth = 50;
			Type = "Armored";
			break;

		case "NormalSkeleton(Clone)":
			maxHealth = 350;
			goldWorth = 50;
			Type = "Dark";
			break;

		case "FastSkeleton(Clone)":
			maxHealth = 250;
			goldWorth = 50;
			Type = "Dark";
			break;

		case "Darkling(Clone)":
			maxHealth = 600;
			goldWorth = 50;
			Type = "Armored";
			break;

		case "BigDarkling(Clone)":
			maxHealth = 800;
			goldWorth = 50;
			Type = "Dark";
			break;

		case "Cyclops(Clone)":
			maxHealth = 550;
			goldWorth = 50;
			Type = "Normal";
			break;

		case "Prowler(Clone)":
			maxHealth = 600;
			goldWorth = 50;
			Type = "Machine";
			break;

		case "GreenGoblin(Clone)":
			maxHealth = 400;
			goldWorth = 50;
			Type = "Nature";
			break;

		case "BlueGoblin(Clone)":
			maxHealth = 450;
			goldWorth = 50;
			Type = "Water";
			break;

		case "RedGoblin(Clone)":
			maxHealth = 500;
			goldWorth = 50;
			Type = "Fire";
			break;

		case "Spider(Clone)":
			maxHealth = 100;
			goldWorth = 50;
			Type = "Nature";
			break;
		case "Crashed":
			//do nothing
			break;
		default:
			maxHealth = 50;
			break;
		}

		if (characterType != "Player(Clone") {
			maxHealth = maxHealth * (GameObject.Find ("TD_Control").GetComponent<Spawning> ().waveCount) / 10;
		}


		currentHealth = maxHealth;

	}


	public void ApplyDamage(float damage,GameObject shooter,string turretType) {


		if (Type == "Armored" && turretType == "Normal") {

			damage = damage * 0.6f;
		}

		if (turretType == "Fire" && Type == "Nature" || Type == "Ice") {

			damage = damage * 1.4f;

		}

		if (turretType == "Fire" && Type == "Fire") {
			
			damage = damage * 0.6f;
			
		}

		if (Type == "Machine" || Type == "Water" && turretType == "Electric") {

			damage = damage * 1.4f;
		}

		if (Type == "Nature" && turretType == "Electric") {

			damage = damage * 0.6f;
		}



		currentHealth = currentHealth - damage;

		if (currentHealth <= 0) {
			character.tag = "Dead";
			control = GameObject.FindGameObjectWithTag ("TDControl");
			GameObject.Find ("TD_Control").GetComponent<goldManager>().addGold (goldWorth);
			GameObject.Find ("TD_Control").GetComponent<killsManager>().addKill();

			control.GetComponent<Spawning>().numAlive -= 1;
			//tAudio.Play ();

			Destroy (character,1f);

		}

	}




}
