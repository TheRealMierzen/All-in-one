using UnityEngine;
using System.Collections;

public class loadSurvival : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Application.LoadLevel("Survival");

    }
}
