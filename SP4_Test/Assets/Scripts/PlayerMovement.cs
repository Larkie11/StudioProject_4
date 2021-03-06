﻿
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float Speed = 0f;
    private float move = 0f;
    private float jump = 0f;
    [SerializeField]
    float jumpPower = 5;
    [SerializeField]
    float boostMultiplier = 2;
    Rigidbody2D myBody;
    bool isGrounded = false;
    bool inair = false;
    [SerializeField]
    Transform top_left;
    [SerializeField]
    Transform bottom_right;
    //What layer is consider a ground
    [SerializeField]
    LayerMask WhatIsGround;

    float lockPos = 0;

    [SerializeField]
    GameObject firebreath;

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform bulletSpawn;
    AudioSource audioEff;
    [SerializeField]
    AudioClip keysound;
    SpriteRenderer Sr;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        Speed = GlobalScript.myCharacters[GlobalScript.CharacterType].speed;
        jumpPower = GlobalScript.myCharacters[GlobalScript.CharacterType].jumpPower;
        audioEff = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
#if UNITY_ANDROID
                      Debug.Log("Android");
#endif

#if UNITY_STANDALONE
        Debug.Log("PC");
#endif

        myBody = this.GetComponent<Rigidbody2D>();
        Sr = this.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "BouncePad")
        {
            myBody.AddForce(new Vector2(GetComponent<Rigidbody2D>().velocity.x, 2500));
        }
        if (other.transform.tag == "key")
        {
            other.gameObject.SetActive(false);
            audioEff.PlayOneShot(keysound);
            GlobalScript.keypickup = true;
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Platform")
        {
            GlobalScript.playerStandingOn = collision.transform.name;
        }

        if (collision.transform.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }

        if(collision.transform.tag == "EnemyBullet")
        {
            if (GlobalScript.shieldisOn)
            {

            }
            else
            {
                Destroy(gameObject);
                GlobalScript.isDead = true;
                Instantiate(Resources.Load("Dead"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }

            //Debug.Log(collision);
           // Destroy(gameObject);
        }

        if(collision.transform.tag == "Spike")
        {
            myBody.AddForce(new Vector2(GetComponent<Rigidbody2D>().velocity.x, 1500));
        }

     

    }

    void Update()
    {
        isGrounded = Physics2D.OverlapArea(top_left.position, bottom_right.position, WhatIsGround);
        //Debug.Log(isGrounded);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
        PlayerAnimation();

        if (transform.position.y < -20)
        {
            Debug.Log("AAAA");
            Destroy(gameObject);
            GlobalScript.isDead = true;
            Instantiate(Resources.Load("Dead"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
#if UNITY_STANDALONE

        move = Input.GetAxis ("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2 (move * Speed, GetComponent<Rigidbody2D>().velocity.y);

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetInteger("State", 3);
                Jump();
            }
        }
        else
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKey(KeyCode.C))
        {
            Attack(transform.position);
        }
        //moving
#endif

#if UNITY_ANDROID

        move = CrossPlatformInputManager.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * Speed, GetComponent<Rigidbody2D>().velocity.y);

        jump = CrossPlatformInputManager.GetAxis("Vertical");




        Debug.Log(jump);

        if (isGrounded)
        {
            if (jump == 1 && inair == false)
            {
                inair = true;
                Jump();
            }
            else
                inair = false;
        }

		//Debug.Log(isBoosting ? boostMultiplier : 1); //returns boostMultiplier if true, 1 if false
		//myBody.AddForce(moveVec * (isBoosting ? boostMultiplier : 1));


#endif
    }

    void Jump()
    {
        //myBody.AddForce(Vector2.up * jumpPower);
        myBody.AddForce(new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpPower));
        anim.SetInteger("State", 3);
    }

    void Attack(Vector2 playerPos)
    {
        GameObject go;
        go = Instantiate(firebreath, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, -90, 0)) as GameObject;
    }

    void Fire() 
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 6;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

    void PlayerAnimation()
    {
        if (move == 0)
        {

            anim.SetInteger("State", 0);
        }

        if (move > 0)
        {
            Sr.flipX = false;
            anim.SetInteger("State", 1);
        }
        else if (move < 0)
        {
            Sr.flipX = true;
            anim.SetInteger("State", 1);
        }
    }

}
