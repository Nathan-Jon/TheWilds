using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleSystemManagerScript : MonoBehaviour {

    //This class is for storing a collection of information about a collectible
    public class collectibleInformation{
        public string name;
        public Texture2D image;
        public string description;
        public collectibleInformation (string name, Texture2D image, string description)
        {
            this.name = name;
            this.image = image;
            this.description = description;
        }
    }

    //This list will store information for all of the items that have been collected so far.
    public List<collectibleInformation> collectedItemsList = new List<collectibleInformation>();

    //I have a strong design recommendation; although I have gotten this system working, I don't think it's the best way it could work.
    //I'm making a note here so as not to forget to bring it up at some point.
    //The way the system works currently is a list of collected items,
    //I would recommend having a list of all items (collected or not) and then just toggling them on in the inventory screen when they are collected.
    //To make that we would need to finalize a list of all the items in the game, this current system just allows you to add abritrary items.
    
    
    
    //This gameobject is the parent object for the collectible notification UI popup
    [SerializeField] GameObject collectibleNotification;

    //The amount of time before the notification becomes transparent (initally zero because the notification should start transparent)
    float opacityCountdown = 0;

    //Initialisation
    private void Start()
    {
        //Assigns the collectibleNotification gameobject to one using the Find function (which finds based on the game object's name)
        collectibleNotification = GameObject.Find("CollectibleNotification");
    }

    // Update is called once per frame
    void Update () {
        //If the notification is above where it should be:
        if (collectibleNotification.GetComponent<RectTransform>().anchoredPosition.y > 270)
        {
            //Move the notification downwards
            collectibleNotification.GetComponent<RectTransform>().anchoredPosition = new Vector3(270, collectibleNotification.GetComponent<RectTransform>().anchoredPosition.y - 1, 0);
        }

        //If the notification is not transparent
        if (opacityCountdown > 0){
            //Count the countdown down: so that the notification will remain opaque for a while (for the player to read it) before disappearing.
            opacityCountdown -= 0.1f;
        }
        //Set the transparency to the "opacity countdown". The actual transparency will increase once the countdown is below 1.0.
        collectibleNotification.GetComponent<CanvasGroup>().alpha = opacityCountdown;



    }

    //Cause a notification to appear on the screen with some text and an image. The text is assumed to be the name of the collectible
    public void Collect(string text, Texture2D image, string description)
    {
        //Move the notification up above the screen
        collectibleNotification.GetComponent<RectTransform>().anchoredPosition = new Vector3(270, 320, 0);
        //Make the notification more than opaque
        opacityCountdown = 20;

        //Set the text of the notification
        collectibleNotification.transform.Find("Text").GetComponent<Text>().text = "New Artifact Collected:\n" + text;

        //Set the image of the notification
        collectibleNotification.transform.Find("RawImage").GetComponent<RawImage>().texture = image;

        //Store the information from the currently-being-collected collectible into the storage array
        collectedItemsList.Add(new collectibleInformation(text, image, description));

        //DEBUG: Print the description of the first item on the list of collected items
        //Debug.Log(GetCollectedCollectible(0).description);
        //DEBUG: Print the length of the collectedItemsList (the number of items collected). Remember: the list does not seperate duplicate items.
        //Debug.Log("Items collected: " + collectedItemsList.Count);
    }


    //Returns the name of an object and it's associated texture by it's index (for use in an inventory screen)
    public collectibleInformation GetCollectedCollectible(int index)
    {
        return collectedItemsList[index];
    }
}
