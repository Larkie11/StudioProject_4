using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrifBoss : MonoBehaviour
{
    int lightningtospawn;
    public List<GameObject> myPlatforms = new List<GameObject>();
    bool playAttack;
    bool playNormal;
    bool playDef;
    [SerializeField]
    float LightningCD;
    [SerializeField]
    int health;
    SpriteRenderer sr;
    int animationState;
    Collider2D collide;
    [SerializeField]
    Canvas canvas;
    Animator ar;
    Vector3 target;
    private string lastClipName;
    int hi;
    public GameObject player;
    Skills skill;
    GameObject myshield;
    bool hideCanvas;
    float hideTimer;
    enum Skills
    {
        Lightning,
        Normal,
        Defense
    }

    // Use this for initialization
    void Start()
    {
        collide = GetComponent<Collider2D>();
        myPlatforms.Clear();
        GlobalScript.GrifHealth = 400;
        hideCanvas = true;
        hideTimer = 0F;
        animationState = 0;
        playAttack = false;
        playNormal = false;
        GlobalScript.isDead = false;
        myshield = GameObject.FindGameObjectWithTag("EnemyShield");
        myshield.SetActive(false);
        skill = GetRandomEnum<Skills>();
        sr = GetComponent<SpriteRenderer>();
        foreach (GameObject platforms in GameObject.FindGameObjectsWithTag("Platform"))
        {
            myPlatforms.Add(platforms);
        }
        ar = GetComponent<Animator>();

        hi = Random.Range(0, myPlatforms.Count);
        lightningtospawn = 2;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GlobalScript.GrifHealth > 0 && collision.transform.tag == "Bullet")
            GlobalScript.GrifHealth -= 2;

        hideTimer = 7F;
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
        if (hideCanvas)
            canvas.enabled = false;
        else
            canvas.enabled = true;

        if (hideTimer > 0)
        {
            hideTimer -= Time.deltaTime;
            hideCanvas = false;
        }
        else if (hideTimer <= 0)
        {
            hideCanvas = true;
        }

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
        if (GlobalScript.GrifHealth > 0)
        {
            if (skill == Skills.Lightning)
            {
                myshield.SetActive(false);
                if (GlobalScript.GrifHealth > 30)
                    lightningtospawn = 2;

                else if (GlobalScript.GrifHealth < 30)
                    lightningtospawn = 5;

                if (GlobalScript.GrifLightningCD <= 0.5)
                {
                    if (!playAttack)
                    {
                        for (int i = 0; i < lightningtospawn; i++)
                        {
                            target = new Vector3(Random.Range(myPlatforms[hi].GetComponent<Collider2D>().bounds.min.x + 4, myPlatforms[hi].GetComponent<Collider2D>().bounds.max.x - 2), -13F, transform.position.z);
                            Instantiate(Resources.Load("LightningTrigger"), target, Quaternion.identity);
                        }
                        animationState = 7;
                    }
                    playAttack = true;
                }
                if (GlobalScript.GrifLightningCD <= 0.1)
                    animationState = 8;

                ar.SetInteger("State", animationState);

                GlobalScript.GrifLightningCD -= Time.deltaTime * 0.3F;
                if (GlobalScript.GrifLightningCD <= 0F)
                {
                    skill = GetRandomEnum<Skills>();
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
                    GlobalScript.GrifDefense = 3F;
                    collide.enabled = true;
                }
                else if (GlobalScript.GrifDefense <= 2F)
                {
                    collide.enabled = false;
                    myshield.SetActive(true);
                }
            }
            if (skill == Skills.Normal)
            {
                myshield.SetActive(false);

                if (GlobalScript.GrifHealth > 30)
                    lightningtospawn = 1;

                else if (GlobalScript.GrifHealth < 30)
                    lightningtospawn = 3;

                if (GlobalScript.GrifNormal <= 0.5)
                {
                    if (!playNormal)
                    {
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
        }
        ar.SetInteger("State", animationState);
    }
}
