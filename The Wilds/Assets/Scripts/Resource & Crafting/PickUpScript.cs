using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author : Nathan Robertson 
/// Checks if a resource is in range, calls the inventory script and destroys the game object of the resource
/// Needs an event handler for pick up added instead of constant update
/// </summary>
public class PickUpScript : MonoBehaviour
{
    IInventory inv;
    public IInventory Inventory { set { inv = value; } }

    //<--------------------------------------- Needs to be set to an event to avoid constant check for pick up ------------------>
    void PickUp()
    {
        //If the 'collect collectible' is pressed (don't know what that button is yet)
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Detect collectibles in a circle. Returns the first one it finds (we assume you can only pick up one collectible at a time)
            Collider2D hit = Physics2D.OverlapCircle(this.gameObject.transform.position, 1, LayerMask.GetMask("Interactable"));
            //If a collectible has been found 
            if (hit != null && hit.gameObject.tag == "Resource")
            {
                //Check if thing collided with has a CollectibleInfo script to take info from

                    inv.CollectedItem(hit.gameObject.GetComponent<Resource>());
                    Destroy(hit.gameObject);

            }
        }
    }

    public void Update()
    {
        PickUp();
    }
}
