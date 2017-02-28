using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    Vector2 TeleporterPos;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "player")
        {
            TeleporterPos = GameObject.Find("TeleportLocation").transform.position;
        }
    }

}
