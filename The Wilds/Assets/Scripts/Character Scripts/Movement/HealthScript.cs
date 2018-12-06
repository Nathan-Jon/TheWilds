using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class HealthScript : MonoBehaviour, IDamageable
{



    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;


    public float CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }
    public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }

    // Use this for initialization
    void Start()
    {
        if (currentHealth == 0)
            Debug.Log("Entity is missing a health Value");

        if (currentHealth != 0)
            maxHealth = currentHealth;
    }

    /// <summary>
    /// Method called to edit health - pass Negative value to lower health and positive to add health
    /// </summary>
    /// <param name="damage"></param>
    public void ChangeHealth(float value)
    {
        //take damage
        currentHealth += value;

        //check to see if health exceeds the maximum value
        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;

        ////UI Nullcheck
        //if (Health_UI != null)
        //{
        //    //Update UI
        //}

        //check to see if health becomes =< 0
        if (currentHealth <= 0)
        {
            //Trigger Death State
            Destroy(gameObject);

            if (gameObject.tag == "Player")
            {  //Change Scene}
            }

        }
    }
}
