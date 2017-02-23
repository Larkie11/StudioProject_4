using UnityEngine;
using System.Collections;

public class Zakboss : MonoBehaviour
{

    float fireballcounter = 0;
    float fireballspawntimer = 0;
    Collider2D collider;
    int animationstate;
   
    Animator animation;
    Attacks attackingskills;
    enum Attacks
    {
        Firepillar,
        Greenfield,
        Crossray,
        Fireballshield,
        Rollingrocks

    }
    // Use this for initialization
    void Start()
    {
        GlobalScript.Zakenragemode = false;
        collider = GetComponent<Collider2D>();
        animationstate = 0;
        GlobalScript.Zakhp = 100;

        animation = GetComponent<Animator>();

    }

    void Fireballskill()
    {



        fireballcounter += 1;
        Instantiate(Resources.Load("fireball1"), new Vector2(transform.position.x + 20F, transform.position.y), Quaternion.identity);

    }
    private void OnColliionEnter2D(Collision2D collision)
    {
        if (GlobalScript.Zakhp > 0 && collision.transform.tag == "Bullet")
            GlobalScript.Zakhp -= 10;
        Debug.Log(GlobalScript.Zakhp);
        Debug.Log("hit");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(GlobalScript.Zakhp);
       
      if(GlobalScript.Zakhp<30)
      {
          GlobalScript.Zakenragemode = true;
          //he mad !!

      }
        if (Input.GetKey(KeyCode.P))
        {
            attackingskills = Attacks.Fireballshield;
            fireballspawntimer = 0;
        }
        if (attackingskills == Attacks.Fireballshield)
        {
            fireballspawntimer += Time.deltaTime;
            //Debug.Log(fireballspawntimer);
            //Debug.Log(fireballcounter);
            if(fireballcounter <6)
            {
                if(fireballspawntimer>3)
                {
                    fireballspawntimer = 0;
                    Fireballskill();
                }
            
            }
           

        }


    }
}
