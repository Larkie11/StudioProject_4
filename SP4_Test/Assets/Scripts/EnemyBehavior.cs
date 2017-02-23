using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    private Animator animator;
    float timer;
    Vector3 target;
    bool moving;
    [SerializeField]
    GameObject firebreath;
    [SerializeField]
    int enemyType;

    [SerializeField]
    string MoveLeftAnim;
    [SerializeField]
    string MoveRightAnim;
    [SerializeField]
    float distanceToDetectPlayer;
    [SerializeField]
    float distanceToAttackPlayer;
    private int currHealth;
    [SerializeField]
    int health;
    [SerializeField]
    float speed;
    [SerializeField]
    float attackCD;
    [SerializeField]
    AnimationClip moveLeft;
    [SerializeField]
    AnimationClip moveRight;
    [SerializeField]
    AnimationClip idleLeft;
    [SerializeField]
    AnimationClip idleRight;
    [SerializeField]
    Image healthbar;
    public List<GameObject> myPlatforms;
    float spawnX;
    float width;
    float width2;
    string nowCollide;
    enum States
    {
        IDLE,
        MOVE,
        ATTACK,
        CHASE,
        END,
    }
    enum Attacks
    {
        NONE,
        FIREBALL,
        MAX
    }
    States enemyStates;
    Attacks attack;
    // Use this for initialization
    void Start()
    {
        nowCollide = null;
        myPlatforms = new List<GameObject>();
        myPlatforms.Clear();
        currHealth = health;
        foreach (GameObject platforms in GameObject.FindGameObjectsWithTag("Platform"))
        {
            myPlatforms.Add(platforms);
        }
        enemyStates = GetRandomEnum<States>();
        timer = 0;
        target = new Vector3(Random.Range(myPlatforms[GenerateEnemy.spawnPointIndex].GetComponent<Collider2D>().bounds.min.x + 4, myPlatforms[GenerateEnemy.spawnPointIndex].GetComponent<Collider2D>().bounds.max.x - 2), -3.7F, transform.position.z);
        timer = Random.Range(2, 5);
        moving = false;
        animator = GetComponent<Animator>();
        healthbar = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponentInChildren<Image>();
        Debug.Log(healthbar.name);
    }
    void UpdateHealthBar()
    {
        healthbar.fillAmount = Map(currHealth, 0, health, 0, 1);
    }
    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
    void EnemyMovement()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (GlobalScript.playerStandingOn == nowCollide && distance < distanceToDetectPlayer)
        {
            if (distance < distanceToAttackPlayer)
            {
                if (attackCD <= 0F && enemyType == 0)
                {
                    Attack(player.transform.position, Attacks.FIREBALL);
                    attackCD = 3F;
                }
            }
            if (attackCD > 0)
                attackCD -= Time.deltaTime;

            if (distance < distanceToDetectPlayer)
            {
                animator.enabled = true;
                transform.position += (player.transform.position - transform.position).normalized * speed * Time.deltaTime;

                if (player.transform.position.x > transform.position.x)
                {
                    animator.Play(moveRight.name);
                }

                else
                {
                    animator.Play(moveLeft.name);
                }
            }
        }
        else
        {
            if (timer >= 0)
                timer -= Time.deltaTime;
            if (timer <= 0 && enemyStates == States.IDLE)
            {
                enemyStates = GetRandomEnum<States>();
                timer = Random.Range(2, 5);
            }

            if (enemyStates == States.IDLE)
            {
                if (transform.position.x < target.x)
                {
                    animator.Play(idleRight.name);
                }
                if (transform.position.x > target.x)
                {
                    animator.Play(idleLeft.name);
                }
            }
            if (enemyStates == States.MOVE)
            {

                if (transform.position.x < target.x)
                {
                    animator.Play(moveRight.name);
                }

                if (transform.position.x > target.x)
                {
                    animator.Play(moveLeft.name);
                }
                transform.position += (target - transform.position).normalized * speed * Time.deltaTime;
            }
            if (!moving && Mathf.Abs(transform.position.x - target.x) < 3)
            {
                GenerateNextWP();
            }
            if (Mathf.Abs(transform.position.x - target.x) < 1)
            {
                enemyStates = GetRandomEnum<States>();
                timer = Random.Range(5, 10);
                moving = false;

                if (enemyStates == States.IDLE)
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Dragon_Left"))
                    {
                        animator.Play("Dragon_Idle");
                    }
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Dragon_Right"))
                    {
                        animator.Play("Dragon_IdleR");
                    }
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Platform")
        nowCollide = collision.transform.name;

        if (collision.transform.tag == "Bullet" && health > 0)
        {
            currHealth -= 2;
            UpdateHealthBar();
            Debug.Log(currHealth + "     " + healthbar.fillAmount);
        }
    }
    void GenerateNextWP()
    {
        if (nowCollide != null)
        {
            width = GameObject.Find(nowCollide).GetComponent<Collider2D>().bounds.min.x + 3.5F;
            width2 = GameObject.Find(nowCollide).GetComponent<Collider2D>().bounds.max.x - 2;
            spawnX = Random.Range(width2, width);
            target = new Vector3(spawnX, transform.position.y, transform.position.z);
            moving = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (nowCollide != null)
        {
            EnemyMovement();
            if (healthbar.fillAmount < 0.5)
                healthbar.color = Color.red;
            else
                healthbar.color = Color.green;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
        }
        if (currHealth <= 0)
        {
            Destroy(gameObject);
            GlobalScript.enemyCount--;
            GlobalScript.howmanytokill++;
        }
        Debug.DrawLine(transform.position, new Vector3(spawnX, transform.position.y, transform.position.z), Color.red);
    }

    static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length - 3));
        return V;
    }
    void GenerateState()
    {

    }
    void Attack(Vector2 playerPos, Attacks a)
    {
        GameObject go;
        if (a == Attacks.FIREBALL)
        {

            go = Instantiate(Resources.Load("bullet01"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        }
    }
}
