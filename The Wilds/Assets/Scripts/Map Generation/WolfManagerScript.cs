using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfManagerScript : MonoBehaviour {


    List<GameObject> wolves = new List<GameObject>();

    [SerializeField]GameObject wolfPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (wolves.Count < 5)
        {
            wolves.Add(Instantiate(wolfPrefab, new Vector3(-4, Random.Range(-5f, 1.4f), -1), Quaternion.identity));
        }
		
	}

    //Change the state of all wolves
    public void ChangeWolfState(wolfScript.WolfState newState)
    {
        foreach (GameObject wolf in wolves)
        {
            wolf.GetComponent<wolfScript>().wolfState = newState;
        }
    }
}
