using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour {

    //An array of craftable scriptable objects
    [SerializeField] private Craftable[] craftable;

    // parent object for craftables
    GameObject WorldCrafted;

    // playable character gameobject
    GameObject player;

    private void Start()
    {
        //initialuse empty parent object
        WorldCrafted = new GameObject("World Crafted Items");
        //find the player game object
        player = GameObject.FindGameObjectWithTag("Player");
    }

    /// <summary>
    /// Places an object in the scene based on its position in the array and the button pressed
    /// </summary>
    void build()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(craftable[0].Prefab, new Vector2(player.transform.position.x,
                player.transform.position.y - (player.GetComponent<BoxCollider2D>().size.y/2f)),
                Quaternion.identity, WorldCrafted.transform);
        }
    }

    private void Update()
    {
        build(); 
    }
}
