using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

     public float playerSpeed = 0.05f; //declare and set playerSpeed
     public float leftRightSpeed = 4;

     
    public bool isJumping = false;
    public bool comingDown = false; 
    public GameObject playerObject; 

    public Rigidbody rb;
    public float gravityScale = 5;
    public AudioSource audioPlayer;

    public AudioClip DeathSFX;

    public ParticleSystem dirtParticles;


     

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundry.leftSide)
            {
                 transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
            
        }  

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if(this.gameObject.transform.position.x < LevelBoundry.rightSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
            }
            
        }  

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        { 
            if (isJumping == false)
            {
                isJumping = true; 
                StartCoroutine(JumpSequence()); 
                dirtParticles.Pause();
            }
        }

        if (isJumping == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
            }
             if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -3, Space.World);
                dirtParticles.Play(); 
            }

            
        }
    }

   IEnumerator JumpSequence()
   {
     yield return new WaitForSeconds(0.45f);
      comingDown = true; 
      yield return new WaitForSeconds(0.55f);
      isJumping = false; 
      comingDown = false; 
   }

     private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CollisionTag")
        {
            audioPlayer.PlayOneShot(DeathSFX);
        }
    }

    
    
}
