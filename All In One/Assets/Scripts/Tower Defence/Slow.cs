using UnityEngine;
using System.Collections;

public class Slow : MonoBehaviour {

    bool slowed;
    public float duration;
    float initSpeed;
    float startTime;
    public GameObject shooter;
    

	// Use this for initialization
	void Start () {

        startTime = Time.time;
        initSpeed = gameObject.GetComponent<NavMeshAgent>().speed;
        slow(shooter, duration);

    }

    void Update (){

        slow(shooter,duration);

    }


    void slow(GameObject shooter,float duration)
    {
        if (Time.time < startTime + duration)
        {
           
            gameObject.GetComponent<NavMeshAgent>().speed = initSpeed - 0.3f * (initSpeed);

        }else
        {

            gameObject.GetComponent<NavMeshAgent>().speed = initSpeed;
            enabled = false;

        }
       

       
        
    }
}
