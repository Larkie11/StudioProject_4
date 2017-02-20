﻿using UnityEngine;
using System.Collections;

public class LightningAttack : MonoBehaviour {

    float position;
    float destroy;
    bool moveDown;
	// Use this for initialization
	void Start () {
        position = Random.Range(9F, 12F);
        moveDown = true;
        destroy = 2F;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.name);
        if(collision.transform.tag == "Platform")
        {
            moveDown = false;
        }
        if (collision.transform.tag == "LightningTrigger")
        {
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
        if (moveDown)
        {
            position -= Time.deltaTime * 30;
        }
        transform.position = new Vector3(transform.position.x, position, transform.position.z);
        if(!moveDown && destroy >= 0F)
        {
            destroy -= Time.deltaTime;
        }
        if (destroy <= 0F)
        {
            Destroy(gameObject);
        }
    }
}
