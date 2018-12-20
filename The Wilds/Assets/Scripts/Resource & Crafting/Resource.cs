using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{

    [SerializeField] string resourceID;
    [SerializeField] float resourceValue;
    [SerializeField] Texture2D texture;
    [SerializeField] Sprite sprite;

    public string getResourceID { get { return resourceID; } }
    public float ResourceValue { get { return resourceValue; } set { resourceValue = value; } }
    public Texture2D Texture { get { return texture; } set { texture = value; } }
    public Sprite Sprite { get { return sprite; } set { sprite = value; } }

    private void Start()
    {
        //null checks 

        if (resourceValue == 0)
            resourceValue = 1;

        if (resourceID == null)
            Debug.Log("A Resource is missing its ID");

        if (texture == null)
            Debug.Log("A resource is missing its texture");

        if (sprite == null)
            sprite = GetComponent<SpriteRenderer>().sprite;

        if (!gameObject.GetComponent<BoxCollider2D>())
            gameObject.AddComponent<BoxCollider2D>();

        //Set the game objects layer
        gameObject.layer = 10;

    }

}
