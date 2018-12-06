using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //length of time until bullet is destroyed 
    [SerializeField] float lifeTime = 2f;
    //Damage Value of the bullet
    float damageVal;
    //maximum number of times the bullet can bounce
    [SerializeField] int maxBounces = 3;

    public float DamageVal { get { return damageVal; } set { damageVal = value; } }

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //descrease the number of bounces by 1 per collision
        maxBounces--;
        //if there are no bounces left destroy the bullet
        if(maxBounces <= 0)
        {
            Destroy(gameObject);
        }

        //Detect if collision object implements IDamageable
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable!=null)
        {
            Destroy(gameObject);
            //call teh change health method from the damageable interface
            damageable.ChangeHealth(damageVal);
        }
    }
}
