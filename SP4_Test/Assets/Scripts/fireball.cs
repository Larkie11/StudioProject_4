using UnityEngine;
using System.Collections;

public class fireball : MonoBehaviour {

    Animator anim1;
    Vector2 zakumpos;
   int  fireballhp;
   int fireballanimationstate;
   float blowuptimer = 0;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    

	// Use this for initialization
	void Start () {
        blowuptimer = 0;
        if (GlobalScript.Zakenragemode == false)        
        fireballhp = 20;
        if (GlobalScript.Zakenragemode == true)
            fireballhp = 30;
        anim1 = GetComponent<Animator>();
        zakumpos = GameObject.Find("zakidle1").transform.position;
        fireballanimationstate = 0;
        //enrage
        if(GlobalScript.Zakenragemode)
        transform.Translate(new Vector2(7f, 0));
       
        // instantiate 4xfirebal
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (fireballhp > 0 && collision.transform.tag == "Bullet")
            fireballhp -= 10;
    
        
    }

	// Update is called once per frame
	void Update () {
	
        /// rotation of the balls 
        /// 
    
        transform.RotateAround(zakumpos, zAxis, 160 * Time.deltaTime);

        if(fireballhp<=0)
        {
            fireballanimationstate = 1;
          
            blowuptimer += Time.deltaTime;
            if(blowuptimer>1)
            {
           
                float temprand = Random.Range(1, 101);
                Debug.Log(temprand);
                if (temprand < 30)
                    Instantiate(Resources.Load("weaponpickup"), new Vector3(transform.position.x, -10.7093f, transform.position.z), Quaternion.identity);

                Destroy(gameObject);
                GlobalScript.fireballcounter -= 1;
            }
         
            //animation to destory 

        }
        anim1.SetInteger("fireballanim", fireballanimationstate);
        //collsiion with  bullet 
     
	}
}
