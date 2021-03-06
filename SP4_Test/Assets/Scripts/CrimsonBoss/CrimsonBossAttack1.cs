﻿using UnityEngine;
using System.Collections;

public class CrimsonBossAttack1 : MonoBehaviour {

    float speed = 5.0f;
    private Vector2 direction;
    GameObject player;

    Rigidbody2D rb;

    private int randNum;
    string toDrop;
	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 position = transform.position;


        if (!GlobalScript.isDead)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Vector2 playerPosition;
            if (player != null)
            {
                playerPosition = player.transform.position;
                rb.velocity = (playerPosition - position).normalized;
            }
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (GlobalScript.CrimsonHealth > 200)
        {
            speed = 5;
        }
        else if (GlobalScript.CrimsonHealth > 75 && GlobalScript.CrimsonHealth < 200)
        {
            speed = 10;
        }
        else if (GlobalScript.CrimsonHealth < 75)
        {
            speed = 15;
        }

        transform.Translate(rb.velocity * speed * Time.deltaTime);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Debug.Log(collision.gameObject.tag);
        if (GlobalScript.shieldisOn && collision.gameObject.tag == "Player")
        {
            randNum = Random.Range(0,3);
            if (randNum == 0)
            {
                toDrop = "Powerup-Shield";
            }
            else if (randNum == 1)
            {
                toDrop = "weaponpickup";
            }
            else if (randNum == 2)
            {
                toDrop = "Powerup-Coin";
            }
            else
            {
                toDrop = "";
            }
            
            if (toDrop != "")
            {
                GameObject go = Instantiate(Resources.Load(toDrop), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
            }
        }
    }

}
