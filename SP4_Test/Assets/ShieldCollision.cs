using UnityEngine;
using System.Collections;

public class ShieldCollision : MonoBehaviour {

    public GameObject platformPref;

    // Use this for initialization
    void Start () {

        platformPref = GameObject.FindGameObjectWithTag("Platform");

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), platformPref.GetComponent<Collider2D>(), true);
        Debug.Log(platformPref.name);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Platform")
        {
            Physics2D.IgnoreCollision(collision.collider, transform.GetComponent<Collider2D>());
            Debug.Log("AAA");
        }
    }
    // Update is called once per frame
    void Update () {
    
	}
}
