using UnityEngine;
using System.Collections;

public class BoxHolder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = transform.position;
        collision.GetComponent<BoxCollider2D>().enabled = false;
        collision.GetComponent<Rigidbody2D>().isKinematic = true;
        //GlobalScript.boxCount ++;
        Destroy(gameObject);
    }
}
