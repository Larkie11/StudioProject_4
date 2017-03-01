using UnityEngine;
using System.Collections;

public class playerbullet : MonoBehaviour {


    [SerializeField]
    float speed = 5f;
 private Vector2 direction;

 AudioSource audioEff;
 [SerializeField]
    AudioClip BulletEnd;

 GameObject joybutton;


 void Start()
 {
     joybutton = GameObject.Find("MobileJoystick");

     audioEff = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        #if UNITY_STANDALONE
        Vector2 position = transform.position;

        
        Vector2 mouseposition;
        mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mouseposition - position).normalized;
#endif
        #if UNITY_ANDROID
        for (var i = 0; i < Input.touchCount; i++)
        {
            if ((joybutton.GetComponent<Collider2D>().bounds.Contains(Input.GetTouch(i).position)))
            {
                //touching joystick
       

                // means touch 1 = on joystick 
                //do nothing 
            }
            else if (!(joybutton.GetComponent<Collider2D>().bounds.Contains(Input.GetTouch(i).position)))
            {
                Vector2 position = transform.position;


                Vector2 mouseposition;
                mouseposition = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                direction = (mouseposition - position).normalized;
            }
        }








#endif
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
            Destroy(gameObject);
            Instantiate(Resources.Load("hitted"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            audioEff.PlayOneShot(BulletEnd);
    }
}
