using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls player movement based off keyboard input
/// Author: Nathan Robertson - Date 07/06/18 - version 0.1
/// </summary>
public class CharacterController_2D : MonoBehaviour
{

    Rigidbody2D rigidbody;

    //boolean to decide movement type
    [SerializeField]
    bool physicsMove = false;

    //controls the movement 
    [SerializeField]
    float speed;
    // Use this for initialization

     public float GetSpeed { get { return speed;  } set { speed = value; } }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        speed = 0.12f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //store the input axies in flaot variables
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //if the bool is true, then run movement based off the rigidbody's addforce function
        #region physics based
        if (physicsMove == true)
        {
            //store the floats into a new vector 2
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            ////Addforce to the rigid body, multiplying the movement
            rigidbody.AddForce(movement * speed);
        }
        #endregion
        //if the bool is false, then run movement based off the tansform position
        #region position based
        else
        {
            //set the position to current position + direction * speed
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                gameObject.transform.position = new Vector2(gameObject.transform.position.x + (moveHorizontal * speed), gameObject.transform.position.y + (moveVertical * speed));
            else gameObject.transform.position = gameObject.transform.position;
        }
        #endregion
    }
}
