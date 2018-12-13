using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour {

    [SerializeField] GameObject treePrefab;

    [SerializeField] int numberOfTrees;

	// Use this for initialization
	void Start () {

        //Create a number of trees
        for (int i = 0; i < numberOfTrees; i++)
        {
            //Create a tree
            GameObject newTree = Instantiate(treePrefab);
            //Set the position of the tree relative to this tile
            newTree.transform.parent = transform;
            newTree.transform.localPosition = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), -1);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
