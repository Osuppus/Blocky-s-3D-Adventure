using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    
   public void OnCollisionEnter(Collision collision)
   {
        if (collision.collider.tag == "CollisionTag")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject); 
        }
    
   }
}
