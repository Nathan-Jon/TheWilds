using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileGeneratorScript : MonoBehaviour {

    [SerializeField] GameObject tilePrefab;
    [SerializeField] int numberOfTiles;

    //This collider is for confining the camera using Cinemachine
    BoxCollider2D bc;

	// Use this for initialization
	void Start () {

        //Create a number of tiles
        for (int i = 0; i < numberOfTiles; i++)
        {
            //Create a tile
            GameObject newTile = Instantiate(tilePrefab);
            //Set the position of the tree relative to this start point
            newTile.transform.parent = transform;
            newTile.transform.localPosition = new Vector3(i*(9.6f*newTile.transform.localScale.x), -(5.4f / 3f), 0);

            //Set the tile's type
            if (i == numberOfTiles-1)
            {
                //Set the last tile to have the 'end' tile type
                newTile.GetComponent<tileScript>().tileType = tileScript.TileType.end;
            } else {
                // This sets the tile to a random TileType. This is too random, should be changed.
                newTile.GetComponent<tileScript>().tileType = (tileScript.TileType)Random.Range(0, 3);
            }
        }

        //Resize the collider (for cinemachine) to the size of the level
        bc = GetComponent<BoxCollider2D>();
        bc.size = new Vector2(6.24f * numberOfTiles, 10.8f);
        bc.offset = new Vector2(((6.24f * numberOfTiles)/2)-(6.24f/2), 0);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
