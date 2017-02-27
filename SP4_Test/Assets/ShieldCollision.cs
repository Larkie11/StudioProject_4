using UnityEngine;
using System.Collections;

public class ShieldCollision : MonoBehaviour {


    // Use this for initialization
    void Start () {   


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision);
       Destroy(collision.gameObject);
       GlobalScript.Shield -= 5;
    }
    // Update is called once per frame
    void Update () {
    
	}
}
