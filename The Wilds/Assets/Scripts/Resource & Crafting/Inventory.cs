using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Nathan Robertson 
/// Manage the contents of the inventory and update UI
/// </summary>
public class Inventory : MonoBehaviour, IInventory
{


    //inventory Value Variables
    [SerializeField] float wood;
    [SerializeField] float oil;
    [SerializeField] float arrows;
    [SerializeField] float shotgunShells;

    //UI Prefabs
    [SerializeField] private GameObject ResAlertPrefab;
    [SerializeField] private GameObject ResUIPrefab;


    #region get / sets
    public float ShotgunShells { get { return shotgunShells; } set { shotgunShells = value; } }

    public float Wood { get { return wood; } set { wood = value; } }

    public float Oil { get { return oil; } set { oil = value; } }

    public float Arrows { get { return arrows; } set { arrows = value; } }

    #endregion

    //Array to hold the resource Ui objects in the scene - added in the unity editor
    [SerializeField] private GameObject[] gameObjectsArray;


    private void Awake()
    {
        //Attach the pick up script to the player and pass the inventory to it
        GameObject.FindGameObjectWithTag("Player").AddComponent<PickUpScript>().Inventory = this;

    }

    /// <summary>
    /// Receives the resource class being collected, updates the UI and inventory values.
    /// </summary>
    /// <param name="res"></param>
    public void CollectedItem(Resource res)
    {

        //<------------------------------There has to be a more efficient way of doing this -------------------------------------------------->

        //each if statement increases  respected resource float based on resource value then updates ther resource UI 

        if (res.getResourceID == "Wood")
        {
            Wood += res.ResourceValue;
            gameObjectsArray[0].GetComponentInChildren<Text>().text = " - " + wood;
        }
        else if (res.getResourceID == "Oil")
        {
            Oil += res.ResourceValue;
            gameObjectsArray[1].GetComponentInChildren<Text>().text = " - " + oil;

        }
        else if (res.getResourceID == "Arrows")
        {
            Arrows += res.ResourceValue;
            gameObjectsArray[2].GetComponentInChildren<Text>().text = " - " + arrows;

        }
        else if (res.getResourceID == "ShotgunShells")
        {
            ShotgunShells += res.ResourceValue;
        }
        //call the collected item alert method
        CollectedItemAlert(res);
    }

    /// <summary>
    /// instantiates an alert ui which appears in the center of the UI canvas
    /// </summary>
    /// <param name="res"></param>
    void CollectedItemAlert(Resource res)
    {
        GameObject ALERT = Instantiate(ResAlertPrefab, new Vector2(Screen.width / 2, Screen.height / 2), ResAlertPrefab.transform.rotation, GameObject.Find("Canvas").transform);

        //Update the UI Text to state the resource value
        ALERT.GetComponentInChildren<Text>().text = "+ " + res.ResourceValue;
        //UIPrefab.GetComponentInChildren<RawImage>().texture = res.Texture;
        ALERT.GetComponentInChildren<Image>().sprite = res.Sprite;
        //Attach the float and fade script to the alert ui object
        ALERT.AddComponent<FloatAndFadeScript>().Initialise(2.5f, 1f,1f);
    }
}
