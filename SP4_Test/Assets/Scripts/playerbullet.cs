using UnityEngine;
using System.Collections;

public class playerbullet : MonoBehaviour {


 public   float speed=5f;
 private Vector2 direction;
	// Use this for initialization
	void Start () {


        Vector2 position = transform.position;

        
        Vector2 mouseposition;
        mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mouseposition - position).normalized;

	}
	
	// Update is called once per frame  
	void Update () {


       
      //  position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        transform.Translate(direction * speed*Time.deltaTime);
        //directionVector = (mousePosition - transform.position).normalized;    //Normalizing the direction vector keeps the same direction but makes its magnitude 1
 

        //transform.Translate(directionVector * moveSpeed * Time.deltaTime)
       
	}

    // delte self   
    void OnCollisionEnter2D(Collision2D hitsmthing)
    {
       

        if (hitsmthing.gameObject.tag != "Player")
        {
            Debug.Log("kys");
            Destroy(gameObject);

        }
        if (hitsmthing.gameObject.tag == "Player")
        {
            Debug.Log("hit player");
            Destroy(gameObject);

        }
    }
}
