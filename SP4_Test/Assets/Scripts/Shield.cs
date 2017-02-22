using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shield : MonoBehaviour
{
    //public ParticleSystem part;
    //public List<ParticleCollisionEvent> collisionEvents;
    //public GameObject GO;
    public GameObject SheildGo;
    public float ShieldDurability;

    void Start()
    {
        // part = GetComponent<ParticleSystem>();
        // collisionEvents = new List<ParticleCollisionEvent>();
        
        SheildGo = GameObject.FindGameObjectWithTag("Shield");
        ShieldDurability = GlobalScript.myCharacters[GlobalScript.CharacterType].shield;
        SheildGo.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && ShieldDurability > 0)
        {
            SheildGo.SetActive(true);
            //ShieldDurability -= Time.deltaTime * 10;
        }
        else
        {
            if(ShieldDurability < 100)
            {
               // ShieldDurability += Time.deltaTime;
            }
            SheildGo.SetActive(false);
        }
    }
}