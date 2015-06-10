using UnityEngine;
using System.Collections;

public class loadPortalRoom : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            Application.LoadLevel("PortalRoom");

    }
}
