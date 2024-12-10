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

    
    public float gravityScale = 5;
    public AudioSource audioPlayer;

    public AudioClip DeathSFX;

    public ParticleSystem dirtParticles;
    public float jumpForce = 5f; // Customizable jump strength

    private Rigidbody rb;

    public bool isGrounded;
    public LayerMask groundLayer; 



    // Start is called before the first frame update

    void Start()

    {

        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component [3, 5, 6]

    }
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
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);

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
        isJumping = false; 
     yield return new WaitForSeconds(0.05f);
        comingDown = true;
        isJumping = true;
      yield return new WaitForSeconds(0.45f);
      isJumping = false; 
      comingDown = false; 
   }

     private void FixedUpdate()
    {
        //rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CollisionTag")
        {
            audioPlayer.PlayOneShot(DeathSFX);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Token")
        {
            Destroy(other.gameObject); 
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.5f, groundLayer); 

    }


}
