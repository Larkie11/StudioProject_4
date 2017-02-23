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
        GlobalScript.Shield = GlobalScript.myCharacters[GlobalScript.CharacterType].maxShield;
        SheildGo.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && GlobalScript.Shield > 0)
        {
            SheildGo.SetActive(true);
            GlobalScript.Shield -= Time.deltaTime * 10;
        }
        else
        {
            if(GlobalScript.Shield < 100)
            {
                GlobalScript.Shield += Time.deltaTime;
            }
            SheildGo.SetActive(false);
        }
    }
}