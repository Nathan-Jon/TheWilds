using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base Class for craftable objects - storing core details
/// </summary>
[CreateAssetMenu(fileName ="NewCraftable", menuName = "Craftables")] 
public class Craftable : ScriptableObject {

    
    //text details
    [TextArea] private string itemDetails;
    //Name
    [SerializeField] private string name;
    //ResourceCost
    [SerializeField] private string resourceType;
    //ResourceCost
    [SerializeField] private float cost;
    //Prefab
    [SerializeField] private GameObject craftableObjectprefab;

    public string ItemDetails { get { return itemDetails;} set { itemDetails = value; } }
    public string Name{ get { return name;} set { name = value; } }
    public string ResourceType { get { return resourceType;} set { resourceType = value; } }
    public float Cost { get { return cost; } set { cost = value; } }
    public GameObject Prefab { get { return craftableObjectprefab; } set { craftableObjectprefab = value; } }


}
