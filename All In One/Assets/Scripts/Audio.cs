using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

	public GameObject Speaker;
	public AudioSource rAudio;
	public AudioClip audio1;
	public AudioClip audio2; 

	// Use this for initialization
	void Start () {

		Speaker = gameObject;
		rAudio = GetComponent<AudioSource> ();

		int play;

		play = Random.Range (1,3);

		if (play == 1) {

			rAudio.PlayOneShot (audio1,0.5f);
			//AudioSource.PlayClipAtPoint(audio1,Speaker.transform.position);
			//yield return WaitForSeconds (audio1.length);

		}


		if (play == 2) {

			rAudio.PlayOneShot (audio2,0.5f);
			//AudioSource.PlayClipAtPoint(audio2,Speaker.transform.position);
			
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
