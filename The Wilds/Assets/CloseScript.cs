using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
     }
}
