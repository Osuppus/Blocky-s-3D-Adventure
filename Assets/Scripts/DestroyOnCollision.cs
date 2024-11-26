using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Player")) 
        {
           
            Destroy(collision.gameObject); 
            
            
            
            
            
        }

        
    }

    


    
    
}
