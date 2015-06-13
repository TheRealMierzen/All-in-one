using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifesManager : MonoBehaviour {

	public int lifes;
	public Text tLifes;
    public Canvas gameOver;
    public GameObject player;

	// Use this for initialization
	void Start () {

		lifes = 20;
	
	}
	
	// Update is called once per frame
	void Update () {

		tLifes.text = "Lives: " + lifes;

        if(lifes == 0)
        {
            player = GameObject.Find("Player(Clone)");
            Cursor.visible = true;
            player.GetComponent<MouseLook>().enabled = false;
            player.GetComponentInChildren<MouseLook>().enabled = false;
            GameObject.Find("UI").GetComponent<Canvas>().enabled = false;
            gameOver.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;

        }
	
	}


	public void decrease() {

		lifes -= 1;

	}
}
