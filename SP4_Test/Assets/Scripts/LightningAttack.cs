using UnityEngine;
using System.Collections;

public class LightningAttack : MonoBehaviour {

    float position;
    float destroy;
    bool moveDown;
	// Use this for initialization
	void Start () {
        position = 12F;
        moveDown = true;
        destroy = 2F;
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.tag == "LightningTrigger")
        {
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
        if (moveDown)
        {
            position -= Time.deltaTime * 100;
        }
        if (transform.position.y <= -4)
        {
            moveDown = false;
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
