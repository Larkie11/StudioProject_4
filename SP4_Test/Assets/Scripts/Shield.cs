using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shield : MonoBehaviour
{
    //public ParticleSystem part;
    //public List<ParticleCollisionEvent> collisionEvents;
    //public GameObject GO;
    int particleCount;
    bool b_ShieldInterval;
    public int ShieldDurability;
    public float ShieldInterval;
    float timer;

    void Start()
    {
       // part = GetComponent<ParticleSystem>();
       // collisionEvents = new List<ParticleCollisionEvent>();
        ShieldDurability = 10000;
    }

    void OnParticleCollision(GameObject other)
    {
        b_ShieldInterval = true;
    }

    void Update()
    {
        if (b_ShieldInterval == true)
        {
            timer += Time.deltaTime;
        }
        if (timer > ShieldInterval)
        {
            ShieldDamged();

        }
    }

    void ShieldDamged()
    {
            timer = 0;
            ShieldDurability--;
            b_ShieldInterval = false;
            Debug.Log(ShieldDurability);
    }
}