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
    float attackCoolDown;
    // Use this for initialization
    void Start()
    {
        enemyStates = GetRandomEnum<States>();
        timer = 0;
        target = new Vector3(Random.Range(-7.5F, 7.50F), -3.7F, transform.position.z);
        timer = Random.Range(2, 5);
        moving = true;
        animator = GetComponent<Animator>();
        attackCoolDown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Distance(player.transform.position, transform.position);
        
        if(distance < 1)
        {
            enemyStates = States.ATTACK;
            if(attackCoolDown <= 0F)
            {
                Attack();
                attackCoolDown = 3F;
            }
            if(player.transform.position.x > transform.position.x)
            {
                animator.Play("GD_Right");
            }

            else
            {
                animator.Play("GD_Left");
            }
        }
        if (attackCoolDown > 0 && enemyStates == States.ATTACK)
            attackCoolDown -= Time.deltaTime;

        if(distance < 4)
        {
            enemyStates = States.CHASE;
            transform.position += (player.transform.position - transform.position).normalized * 0.5F * Time.deltaTime;
        }
        else
        {
            if (timer >= 0)
                timer -= Time.deltaTime;

            if (timer <= 0 && enemyStates == States.IDLE)
            {
                enemyStates = GetRandomEnum<States>();
                Debug.Log(enemyStates);
                timer = Random.Range(2, 5);
            }
            if (enemyStates == States.IDLE)
            {
                animator.Play("Green_Dragon");
            }
            if (timer <= 0 && enemyStates == States.MOVE)
            {
                moving = false;
                target = new Vector3(Random.Range(-7.5F, 7.50F), -3.7F, transform.position.z);
                
            }if (transform.position.x < target.x)
                {
                    animator.Play("GD_Right");
                }
                if (transform.position.x > target.x)
                {
                    animator.Play("GD_Left");
                }
            if (enemyStates == States.MOVE && !moving)
            {
                transform.position += (target - transform.position).normalized * 0.5F * Time.deltaTime;
                timer = Random.Range(2, 5);
                if (Distance(target, transform.position) < 1)
                {
                    moving = true;
                }
            }
            if (moving && timer <= 0)
            {
                enemyStates = GetRandomEnum<States>();
                Debug.Log(enemyStates);
                timer = Random.Range(5, 10);
                moving = false;
            }
        }
        Debug.Log(distance);
        
        int toNextState = Random.Range(2, 5);
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
    void Attack()
    {
        GameObject go = Instantiate(firebreath, new Vector3(transform.position.x,transform.position.y,transform.position.z-3), Quaternion.identity) as GameObject;
    }
}
