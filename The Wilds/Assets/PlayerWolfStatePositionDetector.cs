using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWolfStatePositionDetector : MonoBehaviour {

    GameObject wolfManager;

    [SerializeField]tileScript.TileType currentTileType = tileScript.TileType.normal;

    private void Start()
    {
        wolfManager = GameObject.Find("WolfManager");
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Layer 11 is "background"
        if (coll.gameObject.layer == 11)
        {
            currentTileType = coll.GetComponent<tileScript>().tileType;

            switch (currentTileType)
            {
                case tileScript.TileType.stalk:
                    wolfManager.GetComponent<WolfManagerScript>().ChangeWolfState(wolfScript.WolfState.stalking);
                    break;
                case tileScript.TileType.attack:
                    wolfManager.GetComponent<WolfManagerScript>().ChangeWolfState(wolfScript.WolfState.attacking);
                    break;
                case tileScript.TileType.end:
                    wolfManager.GetComponent<WolfManagerScript>().ChangeWolfState(wolfScript.WolfState.avoiding);
                    break;
                default:
                    wolfManager.GetComponent<WolfManagerScript>().ChangeWolfState(wolfScript.WolfState.stalking);
                    break;
            }
        }
    }
}
