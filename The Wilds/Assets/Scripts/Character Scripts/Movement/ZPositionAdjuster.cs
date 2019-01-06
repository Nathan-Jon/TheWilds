using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZPositionAdjuster : MonoBehaviour {

    float startingZPosition;

	// Use this for initialization
	void Start () {

        //startingZPosition = transform.position.z;

        startingZPosition = -1;

    }
	
	// Update is called once per frame
	void Update () {

        //Calculate the new z position based on the y position. 
        //As the y position gets lower (objects moves down the screen), the z position gets lower (object moves towards the camera).
        float newZPosition = startingZPosition + (transform.position.y / 10);

        //Change the Z position
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);

	}
}
