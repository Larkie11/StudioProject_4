using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrimsonBoss : MonoBehaviour 
{
    int CrimsonAnimation;
    Animator anim;
    Vector2 bossDirection;
    Vector2 randomDirection;
    CrimsonState crimsonState;
    private int frame;

    private int attack1Counter;
    private int attack1Interval;
    private int attack2Counter;
    private int attack2Interval;
    private int directionCounter;
    private int changeDirectionInterval;

    private Vector2 directionToPlayer;
    public GameObject player;

    public static int spawnPointIndex;
    public List<GameObject> myPlatforms;

    public float speed = 10.0f;

    SpriteRenderer Sr;

    enum CrimsonState
    {
        IDLE,
        FLY,
        Attack1,
        Attack2
    }

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
        CrimsonAnimation = 0;
        GlobalScript.CrimsonHealth = 250;
        attack1Counter = 0;
        attack1Interval =30;
        attack2Counter = 0;
        attack2Interval =30;
        directionCounter = 0;
        changeDirectionInterval = Random.Range(1, 10) * 60;

        randomDirection = new Vector2(Random.Range(-100, -100),Random.Range(-100, 100));
        bossDirection = randomDirection.normalized;

        myPlatforms = new List<GameObject>();
        spawnPointIndex = 0;
        myPlatforms.Clear();
        foreach (GameObject platforms in GameObject.FindGameObjectsWithTag("Platform"))
        {
            myPlatforms.Add(platforms);
        }
        Sr = this.GetComponent<SpriteRenderer>();

        Debug.Log("CrimsonBossScript");
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GlobalScript.CrimsonHealth > 0 && collision.transform.tag == "Bullet")
        {
            GlobalScript.CrimsonHealth--;
        }
        if (collision.transform.tag == "Platform" || collision.transform.tag == "Boundary")
        {
            bossDirection *= -1;
        }
        Debug.Log(collision.transform.tag);
    }
	// Update is called once per frame
	void Update ()
    {
        if(player==null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }


        if (transform.position.x > player.transform.position.x)
        {
            Sr.flipX = false;
        }
        else
        {
            Sr.flipX = true;
        }

        if (crimsonState == CrimsonState.IDLE)
        {
            CrimsonAnimation = 0;
        }
        if (crimsonState == CrimsonState.FLY)
        {
            bossMove();
        }
        if (crimsonState == CrimsonState.Attack1)
        {
            bossAttack1();
        }
        if(crimsonState == CrimsonState.Attack2)
        {
            bossAttack2();
        }
        if (GlobalScript.CrimsonHealth == 0)
        {
            CrimsonAnimation = 5;
            if (frame >= 60)
            {
                gameObject.SetActive(false);
            }
        }
        if (frame < 60 && GlobalScript.CrimsonHealth == 0)
        {
            frame++;
        }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            crimsonState = CrimsonState.IDLE;
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            crimsonState = CrimsonState.FLY;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            CrimsonAnimation = 2;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            crimsonState = CrimsonState.Attack1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            crimsonState = CrimsonState.Attack2;
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            CrimsonAnimation = 5;
        }
        anim.SetInteger("CrimsonAnimationState", CrimsonAnimation);
	}

    void bossAttack1()
    {
        CrimsonAnimation = 4;
        attack1Counter++;
        if(attack1Counter > attack1Interval)
        {
            Instantiate(Resources.Load("CrimsonAttack_1"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            attack1Counter = 0;
        }
    }

    void bossAttack2()
    {
        CrimsonAnimation = 3;
        if (GlobalScript.CrimsonLightingEffect < 10)
        CreateAttack2();
    }

    void CreateAttack2()
    {
        spawnPointIndex = Random.Range(0, myPlatforms.Count);

        float width = myPlatforms[spawnPointIndex].GetComponent<Collider2D>().bounds.min.x + 2;
        float width2 = myPlatforms[spawnPointIndex].GetComponent<Collider2D>().bounds.max.x - 2;
        float spawnX = 0;

        spawnX = Random.Range(width, width2);
        Vector2 a = new Vector2(spawnX, myPlatforms[spawnPointIndex].transform.position.y + 2);
        GlobalScript.CrimsonLightingEffect++;
        GameObject go = Instantiate(Resources.Load("AttackEffects"), new Vector2(spawnX, myPlatforms[spawnPointIndex].transform.position.y -12), Quaternion.identity) as GameObject;
    }

    void bossMove()
    {
        CrimsonAnimation = 1;
        directionCounter++;
        if (directionCounter > changeDirectionInterval)
        {
            int randNum = Random.Range(1, 5);
            Debug.Log(randNum);
            if (randNum < 4)
            {
                Vector2 position = transform.position;
                Vector2 playerPosition;
                playerPosition = player.transform.position;
                bossDirection = (playerPosition - position).normalized;
                changeDirectionInterval = Random.Range(1, 10) * 60;
                directionCounter = 0;
            }
            else
            {
                randomDirection = new Vector2(Random.Range(-100, -100), Random.Range(-100, 100));
                bossDirection = randomDirection.normalized;
                changeDirectionInterval = Random.Range(1, 10) * 60;
                directionCounter = 0;
            }
            
        }

        transform.Translate(bossDirection * speed * Time.deltaTime);
        //gameObject.transform.position += new Vector3(1, 0   ,0);
    }
    

}
