using UnityEngine;
using System.Collections;

public class PowerupShield : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GlobalScript.Shield += 20;
            Destroy(gameObject);
        }
    }
}
