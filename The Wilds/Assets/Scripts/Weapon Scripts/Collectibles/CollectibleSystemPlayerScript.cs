using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSystemPlayerScript : MonoBehaviour {


    [SerializeField]CollectibleSystemManagerScript collectibleSystemManagerScript;

    // Use this for initialization
    void Start () {

        //Attach a reference to the collectible system manager. The object isn't useful, we only need the script attached to it which could be anywhere
        collectibleSystemManagerScript = GameObject.Find("GameManager").GetComponent<CollectibleSystemManagerScript>();

    }
	
	// Update is called once per frame
	void Update () {

        //If the 'collect collectible' is pressed (don't know what that button is yet)
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Detect collectibles in a circle. Returns the first one it finds (we assume you can only pick up one collectible at a time)
            Collider2D hit = Physics2D.OverlapCircle(gameObject.transform.position, 1, LayerMask.GetMask("Interactable"));
            //If a collectible has been found 
            if (hit)
            {
                //Check if thing collided with has a CollectibleInfo script to take info from
                if (hit.transform.GetComponent<CollectibleInfo>())
                {
                    //Get the CollectibleInfo script
                    CollectibleInfo CI = hit.transform.GetComponent<CollectibleInfo>();
                    //Get the information out of the script and pass it through the collect function
                    collectibleSystemManagerScript.Collect(CI.text, CI.image, CI.description);
                    //Remove the collectible object (now collected)
                    Destroy(hit.transform.gameObject);
                }
            }
                
            //DEBUG: Simulate the player collecting a collectible
            //collectibleSystemManagerScript.Collect("Curk!", new Texture2D(0, 0), "test");
        }
		
	}
}
