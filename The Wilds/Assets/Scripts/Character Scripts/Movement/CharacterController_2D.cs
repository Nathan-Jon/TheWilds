using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls player movement based off keyboard input
/// Author: Nathan Robertson - Date 07/06/18 - version 0.1
/// </summary>
public class CharacterController_2D : MonoBehaviour
{
    //controls the movement 
    [SerializeField]
    float speed;
    // Use this for initialization

    public float GetSpeed { get { return speed; } set { speed = value; } }

    void Awake()
    {

        if (!GetComponent<Rigidbody2D>())
            gameObject.AddComponent<Rigidbody2D>();
        if (speed == 0)
            speed = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //store the input axies in flaot variables
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //set the position to current position + direction * speed
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + (moveHorizontal * speed), gameObject.transform.position.y + (moveVertical * speed),gameObject.transform.position.z);
        else gameObject.transform.position = gameObject.transform.position;


    }
}
