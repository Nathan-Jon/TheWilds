using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfScript : MonoBehaviour {

    Rigidbody2D rb;

    /*  // List of things for wolves to do
    *   Follow the player (without attacking)
    *   Attack the player. An attack is running at the player, doing damage and then continuing to run away from the player
    *   -Howl for reinforcements-
    *   -Avoid campfires, unless there's a storm-
    */



    [SerializeField] Transform playerPosition;

    enum WolfState { stalking, attacking, avoiding };
    WolfState wolfState = WolfState.stalking;

    //This number is the distance that a wolf will stalk the player at when they're trying not to interact with the player
    private float stalkDistance = 8.5f;
    private float stalkDistanceAllowance = 0.1f;


	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();

        playerPosition = GameObject.Find("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {


        switch (wolfState){

            //Somewhere here should flip the sprite to face towards the player

            case WolfState.stalking:
                float currentDistance = Vector2.Distance(transform.position, playerPosition.position);
                //Move towards player if far away, move away if close. Following player threateningly without really interacting with them
                if (currentDistance > stalkDistance + stalkDistanceAllowance)
                {
                    //Add rigidbody force towards the player. This value is not normalised, wolves will move faster if they are further away
                    rb.AddForce(playerPosition.position - transform.position);
                } else 
                if (currentDistance < stalkDistance - stalkDistanceAllowance) {
                    //Add rigidbody force away from the player. This value is not normalised, wolves will move faster if they are closer
                    rb.AddForce(transform.position - playerPosition.position);
                }
                break;
            case WolfState.attacking:
                //Run towards the player, trying to bite at them as they run past them
                if (Vector2.Distance(transform.position, playerPosition.position) > 0.1)
                {
                    //Rush toward the player
                    rb.AddForce((playerPosition.position - transform.position)*2);
                } else
                {
                    //Do damage to the player
                    //playerPosition.GetComponent<playerScript>().takeDamage(20); // for example. This could be a "wolfAttack" function or something if you want
                    //Once the player is hit, move to 'avoiding' or 'stalking' behaviour, I haven't decided which is more appropriate yet
                    wolfState = WolfState.stalking;
                }
                break;
            case WolfState.avoiding:
                //This behaviour could be used for avoiding either the player or campfires

                break;
            default:
                //The wolfState shouldn't be anything that can't be handled, but just in case it does it sets the wolfState back to stalking anyway
                Debug.LogError("Warning! 'wolfState' unhandled/invalid!", this);
                wolfState = WolfState.stalking;
                break;

        }
		
	}
}
