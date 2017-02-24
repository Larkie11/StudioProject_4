using UnityEngine;
using System.Collections;

public class PowerupCoin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GlobalScript.Score += 10;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
