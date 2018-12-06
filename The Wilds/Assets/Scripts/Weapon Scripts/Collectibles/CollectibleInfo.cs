using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleInfo : MonoBehaviour {

    //Information to be displayed by the notification when this collectible is collected
    public string text;
    public Texture2D image;
    public string description; //The description is not shown in the notification, but will be saved along with the other two variables to be read some other way.


}
