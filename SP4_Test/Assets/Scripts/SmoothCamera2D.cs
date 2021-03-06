﻿using UnityEngine;
 using System.Collections;
 
 public class SmoothCamera2D : MonoBehaviour {

     [SerializeField]
     float dampTime = 0.0f;
     private Vector3 velocity = Vector3.zero;
     Transform target;
    GameObject startingpoint;
    [SerializeField]
    GameObject canvas;
    private void Start()
    {
        startingpoint = GameObject.FindGameObjectWithTag("StartingPoint");
        if (!GlobalScript.isDead)
        {
            if (GlobalScript.CharacterType == 0)
                GlobalScript.go2 = Instantiate(Resources.Load("Player"), new Vector3(startingpoint.transform.position.x, startingpoint.transform.position.y, 0), Quaternion.identity) as GameObject;
            if (GlobalScript.CharacterType == 1)
                GlobalScript.go2 = Instantiate(Resources.Load("Player2"), new Vector3(startingpoint.transform.position.x, startingpoint.transform.position.y, 0), Quaternion.identity) as GameObject;
            if (GlobalScript.CharacterType == 2)
                GlobalScript.go2 = Instantiate(Resources.Load("Player3"), new Vector3(startingpoint.transform.position.x, startingpoint.transform.position.y, 0), Quaternion.identity) as GameObject;
            if (GlobalScript.CharacterType == 3)
                GlobalScript.go2 = Instantiate(Resources.Load("Player4"), new Vector3(startingpoint.transform.position.x, startingpoint.transform.position.y, 0), Quaternion.identity) as GameObject;
        }
        canvas.SetActive(false);
    }
    // Update is called once per frame
    // Update is called once per frame
    public void RespawnPlayer()
    {
        if (GlobalScript.isDead)
        {
            if (GlobalScript.CharacterType == 0)
                GlobalScript.go2 = Instantiate(Resources.Load("Player"), new Vector3(startingpoint.transform.position.x, startingpoint.transform.position.y, 0), Quaternion.identity) as GameObject;
            if (GlobalScript.CharacterType == 1)
                GlobalScript.go2 = Instantiate(Resources.Load("Player2"), new Vector3(startingpoint.transform.position.x, startingpoint.transform.position.y, 0), Quaternion.identity) as GameObject;
            if (GlobalScript.CharacterType == 2)
                GlobalScript.go2 = Instantiate(Resources.Load("Player3"), new Vector3(startingpoint.transform.position.x, startingpoint.transform.position.y, 0), Quaternion.identity) as GameObject;
            if (GlobalScript.CharacterType == 3)
                GlobalScript.go2 = Instantiate(Resources.Load("Player4"), new Vector3(startingpoint.transform.position.x, startingpoint.transform.position.y, 0), Quaternion.identity) as GameObject;
            GlobalScript.isDead = false;
        }
        canvas.SetActive(false);
    }
    void Update () 
     {

        // if (GlobalScript.playerToRender == "Santa")
        //  GlobalScript.go2 = Instantiate(Resources.Load("Player 2"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        if (GlobalScript.isDead)
        {
            canvas.SetActive(true);
        }

        if (target == null && GlobalScript.go2 != null)
            target = GlobalScript.go2.transform;
       
        if (target)
         {
             Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
             Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.3f, point.z)); //(new Vector3(0.5, 0.5, point.z));
             Vector3 destination = transform.position + delta;
             transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
         }
     
     }
 }