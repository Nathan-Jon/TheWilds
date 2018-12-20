using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFireScript : MonoBehaviour
{

    //float to be used for the maximum length of time the fire can be used for
    [SerializeField] float fireTime;
    //flaot for the current time
    [SerializeField] float time;

    // Use this for initialization
    void Start()
    {
        //create and set the radius of the circle trigger collider
        gameObject.AddComponent<CircleCollider2D>().radius = 18;
        gameObject.GetComponent<CircleCollider2D>().isTrigger = true;

        //Make a null check on the fireTime and apply a value
        if (fireTime == 0)
        {
            Debug.Log("The fire hasn't been correctly assigned a fire time");
            fireTime = 10;
        }
    }


    //get the distance of the player from the center of the fire place and change the amount of heat they recieve - closer is more further is less
    //( possibly use and exponential growth function ) 
    // Min Val - Max VAL - GROWTH RATE - distance


    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug the range
        Debug.DrawLine(gameObject.transform.position, collision.transform.position);


    }


    private void Update()
    {
        //Increment the time
        time += Time.deltaTime;
        //destroy the fire game object if the fire has been on for too long
        if (time >= fireTime)
            Destroy(gameObject);
    }
}
