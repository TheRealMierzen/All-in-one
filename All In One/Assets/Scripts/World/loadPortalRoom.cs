using UnityEngine;
using System.Collections;

public class loadPortalRoom : MonoBehaviour {

    void Start (){

        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);

    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            Application.LoadLevel("PortalRoom");

    }
}
