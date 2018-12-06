using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotScript : MonoBehaviour
{

    [SerializeField]
    GameObject Bullet;
    //the Location of which the bullet will spawn
    Transform BulletSpawn;
    //the direction of which the bullet will fire in
    Vector2 TargetDirection;

    //The force which will be added to the rigidbody of the bullet
    [SerializeField] float bulletForce;
    [SerializeField] float bulletDamage;


    void Start()
    {
        //get the transform of the slingshot
        BulletSpawn = gameObject.transform;
        if (!BulletSpawn)
        {
            Debug.LogError("Bullet spawn point isnt being found");
        }
    }


    private void shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        //create a local version of the bulletspawnlocation
        Vector2 BulletSpawnPosition = BulletSpawn.transform.position;
        //Find the direction of which the bullet will fire
        TargetDirection = mousePosition; 
        //Raycast from the point the bullet will spawn at, into the target direction - Can add layerMasks of which the raycast won't hit after the distance value
        RaycastHit2D hit = Physics2D.Raycast(BulletSpawnPosition, TargetDirection, 100);

        //spawn bullet
        GameObject bullet = Instantiate(Bullet);
        bullet.GetComponent<Bullet>().DamageVal = bulletDamage;
        //set bullet position to bullet spawn position
        bullet.transform.position = transform.position;
        //add force to bullet in mouse direction
        bullet.GetComponent<Rigidbody2D>().AddForce(-(BulletSpawnPosition - TargetDirection) * bulletForce);
        //Force bullet to ignore the player collision 
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());

        //Debug the raycast so we can see the bullet
        Debug.DrawLine(BulletSpawnPosition, TargetDirection, Color.cyan);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Shot fired!");
            shoot();
        }
    }
}
