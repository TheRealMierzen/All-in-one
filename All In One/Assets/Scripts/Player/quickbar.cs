using UnityEngine;
using System.Collections;

public class quickbar : MonoBehaviour {

    GameObject[] quickBar = new GameObject[10];
    GameObject selected;
    int selectedItem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        checkSelected();

    }


    void checkSelected()
    {

        if (selected != quickBar[selectedItem])
        {
            selected = quickBar[selectedItem];
        }

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {

            selectedItem = 0;

        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {

            selectedItem = 1;

        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {

            selectedItem = 2;

        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {

            selectedItem = 3;

        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {

            selectedItem = 4;

        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {

            selectedItem = 5;

        }
        if (Input.GetKeyUp(KeyCode.Alpha7))
        {

            selectedItem = 6;

        }
        if (Input.GetKeyUp(KeyCode.Alpha8))
        {

            selectedItem = 7;

        }
        if (Input.GetKeyUp(KeyCode.Alpha9))
        {

            selectedItem = 8;

        }
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {

            selectedItem = 9;

        }

        selected = quickBar[selectedItem];

    }



}
