using UnityEngine;
using System.Collections;

public class Zakboss : MonoBehaviour
{

 
    float fireballspawntimer = 0;
    public GameObject rockposition1;
    public GameObject rockposition2;
    float skill1duration;
    public int randommintime=1;
    public int randommaxtime = 3;
    bool fireballmaxedspawn = false;
    Collider2D collider;
    int animationstate;
    private float rocktimer1;
    private int rockspawntimer1=1;
    private float rocktimer2;
    private int rockspawntimer2 = 1;
    Animator anim;
    Attacks attackingskills;
    enum Attacks
    {
        //Firepillar,
       // Greenfield,
        //Crossray,
        Fireballshield,
        Rollingrocks

    }
    // Use this for initialization
    void Start()
    {
        randommintime = 1;
        randommaxtime = 10;
        GlobalScript.Zakenragemode = false;
        collider = GetComponent<Collider2D>();
        skill1duration = 10f;
        GlobalScript.Zakhp = 100;
        animationstate = 0;
        anim = GetComponent<Animator>();
          attackingskills = GetRandomEnum<Attacks>();
    }


    void Rollingrockskill1()
    {
        Instantiate(Resources.Load("ballball"), rockposition1.transform.position, Quaternion.identity);
        
    }
    void Rollingrockskill2()
    {
        Instantiate(Resources.Load("ballball"), rockposition2.transform.position, Quaternion.identity);

    }
    void Fireballskill()
    {


        Instantiate(Resources.Load("fireball1"), new Vector2(transform.position.x + 20F, transform.position.y), Quaternion.identity);
        GlobalScript.fireballcounter += 1;

    }
  
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GlobalScript.Zakhp > 0 && collision.transform.tag == "Bullet")
        {
            GlobalScript.Zakhp -= 10;
        }


    }
    int  randomtimer(int x)
    {
        x = Random.Range(randommintime, randommaxtime);
        return x;
        //rockspawntimer1 = Random.Range(randommintime,randommaxtime);
        //rockspawntimer2 = Random.Range(randommintime, randommaxtime);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(attackingskills);
      //  Debug.Log(skill1duration);
        rocktimer1 += Time.deltaTime;
        skill1duration += Time.deltaTime;
        if(skill1duration>=20)
        {
            skill1duration = 0;
            attackingskills = GetRandomEnum<Attacks>();
        }
        //Debug.Log(rockspawntimer2);
        //Debug.Log(rocktimer2);
        
        rocktimer2 += Time.deltaTime;

    
        if(attackingskills==Attacks.Rollingrocks)
        {
            animationstate = 2;
            if (rocktimer1 >= rockspawntimer1)
            {
                rockspawntimer1 = randomtimer(rockspawntimer1);
                Rollingrockskill1(); //called once 
                rocktimer1 = 0;
             

            }
            if (rocktimer2 >= rockspawntimer2)
            {
                rockspawntimer2 = randomtimer(rockspawntimer2);
                Rollingrockskill2(); //called once 
                rocktimer2 = 0;


            }
        }
        if(GlobalScript.Zakhp<=0)
        {
            animationstate = 10;

            Destroy(gameObject, 3f);
        }
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
         
            animationstate = 1;
            fireballspawntimer += Time.deltaTime;
            //Debug.Log(fireballspawntimer);
            
            if (GlobalScript.fireballcounter < 6)
            {
                if(fireballspawntimer>3)
                {
                    fireballspawntimer = 0;
                    Fireballskill();
                }
            
            
          
            }
           

        }
        anim.SetInteger("animationstate", animationstate);

    }

    static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }
}
