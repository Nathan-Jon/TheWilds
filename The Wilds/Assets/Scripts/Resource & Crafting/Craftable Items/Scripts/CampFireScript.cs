using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFireScript : MonoBehaviour, IFire
{

    //float to be used for the maximum length of time the fire can be used for
    [SerializeField] float fireTime;
    //flaot for the current time
    [SerializeField] float time;

    //the strength/heat of the fires core
    [SerializeField] float intensity;

    /// <summary>
    /// calculate and return the heat value of the 
    /// </summary>
    public float HeatStrength { get { return intensity; } }
    


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
        if (intensity == 0)
            intensity = 5;
    }


    //get the distance of the player from the center of the fire place and change the amount of heat they recieve - closer is more further is less
    //( possibly use and exponential growth function ) 
    // Min Val - Max VAL - GROWTH RATE - distance


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug the range
        Debug.DrawLine(gameObject.transform.position, collision.transform.position);
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<TemperatureHealthScript>().FireHeat = intensity;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<TemperatureHealthScript>().FireHeat = intensity;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<TemperatureHealthScript>().FireHeat = 0;

        }
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
