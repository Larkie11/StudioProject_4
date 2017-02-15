using UnityEngine;
using System.Collections;
using System.Linq;

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
        enemyStates = GetRandomEnum<States>();
        timer = 0;
        target = new Vector3(Random.Range(-7.5F, 7.50F), -3.7F, transform.position.z);
        timer = Random.Range(2, 5);

        moving = false;
        animator = GetComponent<Animator>();
    }
    void EnemyMovement()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Distance(player.transform.position, transform.position);

        if (distance < distanceToAttackPlayer)
        {
            enemyStates = States.ATTACK;
            if (attackCD <= 0F && enemyType == 0)
            {
                Attack(player.transform.position, Attacks.FIREBALL);
                attackCD = 3F;
            }
        }
        if (attackCD > 0 && enemyStates == States.ATTACK)
            attackCD -= Time.deltaTime;

        if (distance < distanceToDetectPlayer)
        {
            animator.enabled = true;
            enemyStates = States.CHASE;
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
        else
        {
            if (timer >= 0)
                timer -= Time.deltaTime;
            if (timer <= 0)
            {
                enemyStates = GetRandomEnum<States>();
                Debug.Log(enemyStates);
                timer = Random.Range(2, 5);

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

            if (transform.position.x < target.x)
            {
                animator.Play(moveRight.name);
            }

            if (transform.position.x > target.x)
            {
                animator.Play(moveLeft.name);
            }
            if (enemyStates == States.MOVE)
            {
                transform.position += (target - transform.position).normalized * speed * Time.deltaTime;
                timer = Random.Range(2, 5);
                if (Distance(target, transform.position) < 1)
                {
                    target = new Vector3(Random.Range(-7.5F, 7.50F), -3.7F, transform.position.z);
                    moving = true;
                }
            }
            if (moving && timer <= 0)
            {
                enemyStates = GetRandomEnum<States>();
                Debug.Log(enemyStates);
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
    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    private float Distance(Vector3 pos1, Vector3 pos2)
    {
        return Vector3.Distance(pos1, pos2);
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
            if (transform.position.x < playerPos.x)
                go = Instantiate(firebreath, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 90, 0)) as GameObject;
            else
                go = Instantiate(firebreath, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, -90, 0)) as GameObject;
        }
    }
}
