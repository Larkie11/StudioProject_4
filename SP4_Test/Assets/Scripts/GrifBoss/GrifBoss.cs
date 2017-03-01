using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrifBoss : MonoBehaviour
{
    int lightningtospawn;
    float timetoDestroy;
    public List<GameObject> myPlatforms = new List<GameObject>();
    //Animation
    bool playAttack;
    bool playNormal;
    bool playDef;
    int animationState;

    [SerializeField]
    float LightningCD;
    [SerializeField]
    int health;

    Vector3 target;
    private string lastClipName;
    int hi;
    public GameObject player;
    Skills skill;
    //Getting component
    GameObject myshield;
    [SerializeField]
    Canvas canvas;
    SpriteRenderer sr;
    Collider2D collide;
    Animator ar;
    bool hideCanvas;
    float hideTimer;
    AudioSource audioEff;

    //Audio clips
    [SerializeField]
    AudioClip roar;
    [SerializeField]
    AudioClip shield;
    [SerializeField]
    AudioClip lightning;
    [SerializeField]
    AudioClip hurt;

    //Sound playing
    bool playSound = false;
    bool playLightning = false;

    //Skills
    enum Skills
    {
        Lightning,
        Normal,
        Defense
    }
    // Use this for initialization
    void Start()
    {
        //Finding and getting components
        collide = GetComponent<Collider2D>();
        myshield = GameObject.FindGameObjectWithTag("EnemyShield");
        audioEff = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        ar = GetComponent<Animator>();
        myPlatforms.Clear();
        foreach (GameObject platforms in GameObject.FindGameObjectsWithTag("Platform"))
        {
            myPlatforms.Add(platforms);
        }
        //All other initializing
        timetoDestroy = 0;
        GlobalScript.GrifHealth = 400;
        hideCanvas = true;
        hideTimer = 0F;
        animationState = 0;
        playAttack = false;
        playNormal = false;
        canvas.enabled = true;
        myshield.SetActive(false);
        //Randoming skill
        skill = GetRandomEnum<Skills>();
        
        hi = Random.Range(0, myPlatforms.Count);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GlobalScript.GrifHealth > 0 && collision.transform.tag == "Bullet")
        {
            GlobalScript.GrifHealth -= 5;
            audioEff.PlayOneShot(hurt);
        }
    }
    static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }
    // Update is called once per frame
    void Update()
    { 
        //Lock rotation
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
        if (!GlobalScript.isDead)
        {
            if (!player)
                player = GameObject.FindGameObjectWithTag("Player");
            if (transform.position.x > player.transform.position.x)
            {
                sr.flipX = false;
            }
            else
                sr.flipX = true;

            if (!playAttack && !playNormal)
                transform.position += (player.transform.position - transform.position).normalized * 0.5F * Time.deltaTime;
        }
        //Changing how many lightning spawns when red bar
        if (GlobalScript.GrifHealth > 200)
            lightningtospawn = 2;

        if (GlobalScript.GrifHealth < 200)
            lightningtospawn = 5;

        if (GlobalScript.GrifHealth > 0)
        {
            //If random till lightning skill
            if (skill == Skills.Lightning)
            {
                myshield.SetActive(false);
             
                if (GlobalScript.GrifLightningCD <= 0.5)
                {
                    if (!playAttack)
                    {
                        audioEff.PlayOneShot(roar);

                        //Spawn lightning randomly
                        for (int i = 0; i <= lightningtospawn; i++)
                        {
                            target = new Vector3(Random.Range(myPlatforms[hi].GetComponent<Collider2D>().bounds.min.x + 4, myPlatforms[hi].GetComponent<Collider2D>().bounds.max.x - 2), -13F, transform.position.z);
                            Instantiate(Resources.Load("LightningTrigger"), target, Quaternion.identity);
                        }
                        animationState = 7;
                    }
                    playAttack = true;
                }
                //Set animation, play lightning sound effect
                if (GlobalScript.GrifLightningCD <= 0.1)
                {
                    animationState = 8;
                    if(!playLightning)
                    {
                        audioEff.PlayOneShot(lightning);
                        playLightning = true;
                    }
                }
                ar.SetInteger("State", animationState);

                GlobalScript.GrifLightningCD -= Time.deltaTime * 0.3F;
                //Reset
                if (GlobalScript.GrifLightningCD <= 0F)
                {
                    skill = GetRandomEnum<Skills>();
                    playLightning = false;
                    GlobalScript.GrifLightningCD = 1;
                    animationState = 8;
                    playAttack = false;
                }
            }

            if (skill == Skills.Defense)
            {
                GlobalScript.GrifDefense -= Time.deltaTime * 0.3F;
                animationState = 0;

                if (GlobalScript.GrifDefense <= 0F)
                {
                    skill = GetRandomEnum<Skills>();
                    myshield.SetActive(false);
                    GlobalScript.GrifDefense = 2F;
                    collide.enabled = true;
                    playSound = false;
                }
                else if (GlobalScript.GrifDefense <= 1F)
                {
                    collide.enabled = false;
                    myshield.SetActive(true);
                    if (!playSound)
                    {
                        audioEff.PlayOneShot(shield);
                        playSound = true;
                    }
                }
            }
            if (skill == Skills.Normal)
            {
                myshield.SetActive(false);


                if (GlobalScript.GrifNormal <= 0.5)
                {
                    if (!playNormal)
                    {
                        audioEff.PlayOneShot(roar);
                        if (transform.position.x > player.transform.position.x)
                        {
                            GlobalScript.flipAttack = true;
                            Instantiate(Resources.Load("GrifHit"), new Vector3(transform.position.x - 2F, -15, transform.position.z), Quaternion.identity);
                        }
                        else
                        {
                            GlobalScript.flipAttack = false;
                            Instantiate(Resources.Load("GrifHit"), new Vector3(transform.position.x + 2F, -15, transform.position.z), Quaternion.identity);
                        }
                        animationState = 5;
                    }
                    playNormal = true;
                }


                GlobalScript.GrifNormal -= Time.deltaTime * 0.3F;

                if (GlobalScript.GrifNormal <= 0F)
                {
                    GlobalScript.GrifNormal = 2F;
                    skill = GetRandomEnum<Skills>();
                    playNormal = false;
                    animationState = 6;
                    GlobalScript.numberOfGrifHits = 0;
                }
            }
        }
        else
        {
            if (animationState == 5)
                animationState = 17;
            else if (animationState == 7)
                animationState = 16;
            else
                animationState = 15;
            canvas.enabled = false;
            if(timetoDestroy == 0F)
            timetoDestroy = 1.5F;

            if (timetoDestroy > 0)
                timetoDestroy -= Time.deltaTime;
            if (timetoDestroy <= 0)
                Destroy(gameObject);

            Debug.Log(timetoDestroy);
        }
       
        ar.SetInteger("State", animationState);
    }
}
