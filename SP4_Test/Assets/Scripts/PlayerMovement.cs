
using UnityEngine;
 using System.Collections;
using UnityStandardAssets.CrossPlatformInput; 

 public class PlayerMovement : MonoBehaviour
 {
     public float moveForce = 1.5f;
     public float speed = 1.5f;
     public float jumpPower = 5;
     public float boostMultiplier = 2;      
     Rigidbody2D myBody;
     bool isGrounded = false;
     public Transform top_left;
     public Transform bottom_right;
     //What layer is consider a ground
     public LayerMask WhatIsGround;

     void Start()
     {
            #if UNITY_ANDROID
                      Debug.Log("Android");
            #endif

            #if UNITY_STANDALONE
                      Debug.Log("PC");
            #endif

                      myBody = this.GetComponent<Rigidbody2D>();
     }
	
     void Update ()
     {
         isGrounded = Physics2D.OverlapArea(top_left.position, bottom_right.position, WhatIsGround);
         //Debug.Log(isGrounded);

         #if UNITY_STANDALONE
         
         if (isGrounded)
         {
             if (Input.GetKey(KeyCode.Space))
             {
                 Jump();
             }
         }

         if (Input.GetKey(KeyCode.A))
         {
             transform.position += Vector3.left * speed * Time.deltaTime;
         }
         if (Input.GetKey(KeyCode.D))
         {
             transform.position += Vector3.right * speed * Time.deltaTime;
         }
         #endif        

       #if UNITY_ANDROID
         
         Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),
		CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
		bool isBoosting = CrossPlatformInputManager.GetButton("Boost");
        bool isJumping = CrossPlatformInputManager.GetButton("Jump");

        Debug.Log(isGrounded);

        if (isGrounded)
        {
            if (isJumping)
            {
                Jump();
            }
        }
        
		//Debug.Log(isBoosting ? boostMultiplier : 1); //returns boostMultiplier if true, 1 if false
		myBody.AddForce(moveVec * (isBoosting ? boostMultiplier : 1));


      #endif
     }

     void Jump()
     {
         myBody.AddForce(Vector2.up * jumpPower);
     }

 }
