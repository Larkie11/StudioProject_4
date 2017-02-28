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
        fireballhp = 30;
        if (GlobalScript.Zakenragemode == true)
            fireballhp = 50;
        anim1 = GetComponent<Animator>();
        zakumpos = GameObject.Find("zakidle1").transform.position;
        fireballanimationstate = 0;
        //enrage
       // transform.Translate(new Vector2(10f, 0));
       
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
                Destroy(gameObject);
                GlobalScript.fireballcounter -= 1;
            }
         
            //animation to destory 

        }
        anim1.SetInteger("fireballanim", fireballanimationstate);
        //collsiion with  bullet 
     
	}
}
