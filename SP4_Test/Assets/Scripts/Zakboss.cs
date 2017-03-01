using UnityEngine;
using System.Collections;

public class Zakboss : MonoBehaviour
{
    float randomrockside;

    [SerializeField]
    Canvas canvas;

    float fireballspawntimer = 0;

    [SerializeField]
    GameObject rockposition1;
    [SerializeField]
    GameObject rockposition2;
    float skill1duration;
    [SerializeField]
    int randommintime = 1;
    bool enraged = false;
    [SerializeField]
    int randommaxtime = 3;
    bool fireballmaxedspawn = false;

    int animationstate;
    private float rocktimer1;
    private int rockspawntimer1=1;
    private float rocktimer2;
    private int rockspawntimer2 = 1;
    Animator anim;
    Attacks attackingskills;
    Attacks tempatk;

    GameObject rockskill;
    GameObject fireskill;

    [SerializeField]
    AudioClip rock1;
    [SerializeField]
    AudioClip fireshiled1;

    AudioSource audioEff;

    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

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
        canvas.enabled = true;

        audioEff = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        randommintime = 1;
        randommaxtime = 10;
        GlobalScript.Zakenragemode = false;
   
        randomrockside = 1;
        skill1duration = 10f;
        GlobalScript.Zakhp = 100;
        animationstate = 0;
        anim = GetComponent<Animator>();
          attackingskills = GetRandomEnum<Attacks>();
          GlobalScript.isDead = false;
    }


    void Rollingrockskill1()
    {
        audioEff.PlayOneShot(rock1);
        Instantiate(Resources.Load("ballball"), rockposition1.transform.position, Quaternion.identity);
        Instantiate(Resources.Load("zakrockskill"), new Vector3(transform.position.x , transform.position.y+5f, transform.position.z), Quaternion.identity);

    }
    void Rollingrockskill2()
    {
        audioEff.PlayOneShot(rock1);
        Instantiate(Resources.Load("ballball"), rockposition2.transform.position, Quaternion.identity);
        Instantiate(Resources.Load("zakrockskill"), new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z), Quaternion.identity);
    }
    void Fireballskill()
    {
        audioEff.PlayOneShot(fireshiled1);
        //transform.Translate(new Vector2(10f, 0));
       Instantiate(Resources.Load("fireball1"), new Vector2(transform.position.x + 6.5F, transform.position.y), Quaternion.identity);
       Instantiate(Resources.Load("zakfireskill"), new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z), Quaternion.identity);
        if(GlobalScript.Zakenragemode==true)
        {
            Instantiate(Resources.Load("fireball1"), new Vector2(transform.position.x + 14f, transform.position.y), Quaternion.identity);
        }
          
        GlobalScript.fireballcounter += 1;

    }
  
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GlobalScript.Zakhp > 0 && collision.transform.tag == "Bullet")
        {
            GlobalScript.Zakhp -= 2;
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
        if(GlobalScript.Zakhp<50&&enraged==false)
        {
            animationstate = 3;
            skill1duration = 10;
            attackingskills =Attacks.Fireballshield;
            enraged = true;

        }

     
      //  Debug.Log(attackingskills);
          //Debug.Log(skill1duration);
        rocktimer1 += Time.deltaTime;
        skill1duration += Time.deltaTime;
        if (skill1duration >= 10)
        {
         
            skill1duration = 0;
            if (GlobalScript.Zakhp > 0)
                tempatk = attackingskills;
        
            if(tempatk==attackingskills)
            {
                
                attackingskills = GetRandomEnum<Attacks>();
            }

        }
        //Debug.Log(rockspawntimer2);
        //Debug.Log(rocktimer2);

        rocktimer2 += Time.deltaTime;


        if (attackingskills == Attacks.Rollingrocks)
        {
            animationstate = 2;
          
            if(randomrockside==1)
            {
                if (rocktimer1 >= rockspawntimer1)
                {
                    randomrockside = Random.Range(1, 3);
                    rockspawntimer1 = randomtimer(rockspawntimer1);
                    Rollingrockskill1(); //called once 
                    rocktimer1 = 0;


                }
            }
            else if (randomrockside==2)
            {
                if (rocktimer2 >= rockspawntimer2)
                {
                    randomrockside = Random.Range(1, 3);
                    rockspawntimer2 = randomtimer(rockspawntimer2);
                    Rollingrockskill2(); //called once 
                    rocktimer2 = 0;


                }
            }
       
        }
        if (GlobalScript.Zakhp <= 0)
        {
            animationstate = 10;
            canvas.enabled = false;

            Destroy(gameObject, 3f);
        }
        if (GlobalScript.Zakhp < 30)
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

            if (GlobalScript.fireballcounter < 9)
            {
                if (fireballspawntimer > 1)
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
