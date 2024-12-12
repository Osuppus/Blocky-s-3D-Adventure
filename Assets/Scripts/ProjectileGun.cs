using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
     public GameObject projectilePrefab; //declare and set the projectilePrefab GameObject in the Inspector
    public Transform launchPoint; //the position from which a projectile will launch

    public float shootTime = 0.5f; //cooldown time amount b/w projectile firing, set in inspector
                                  //currently set to 0.5
    public float shootCount; //the cooldown timer itself, set in inspector

    public float speed;

    public Rigidbody projectile;

    



    // Start is called before the first frame update
    void Start()
    {
        shootCount = shootTime; //set the shootCounter timer equal to shootTime when the scene starts
    }

    // Update is called once per frame
    void Update()
    {
        //if the Left Mouse Button is pressed AND the shootCounter is reset to 0 or less than 0
        //if(Input.GetButtonDown("Fire1") && shootCounter <= 0)
        if (CoinManager.instance.canShoot && Input.GetMouseButtonDown(0) && shootCount <= 0)
        {
           var clone = Instantiate(projectile, transform.position, transform.rotation);
           clone.velocity = Vector3.forward * speed; 
            //Instantiate needs 3 things! (1,2,3)
            //1. what are you instantiating?
            //2. Where are you instantiating it?
            //3. What is the rotation you're instantiating it with? USE Quaternion.identity

            shootCount = shootTime; //restart the cooldown time to disable ability to shoot
        }

        shootCount -= Time.deltaTime; //reduce cooldown time
    }

}
