using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author : Nathan Roberton 
/// Interface for the Inventory Script
/// </summary>
public interface IInventory  {

	float ShotgunShells { get; set; }
	float Wood { get; set; }
	float Oil { get; set; }
	float Arrows { get; set; }

    void CollectedItem(Resource res);
    void SubtractResource(string id, float cost);


}
