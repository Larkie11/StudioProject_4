using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class Shield : MonoBehaviour
{
    //public ParticleSystem part;
    //public List<ParticleCollisionEvent> collisionEvents;
    //public GameObject GO;
    public GameObject SheildGo;
    public float ShieldDurability;
    private bool HoldingButtonDown;

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
    #if UNITY_STANDALONE
            if (Input.GetKey(KeyCode.Mouse1) && GlobalScript.Shield > 0)
            {
                SheildGo.SetActive(true);
                GlobalScript.shieldisOn = true;
                GlobalScript.Shield -= Time.deltaTime * 10;
            }
            else
            {
                if(GlobalScript.Shield < GlobalScript.myCharacters[GlobalScript.CharacterType].maxShield)
                {
                    GlobalScript.shieldisOn = false;
                    GlobalScript.Shield += Time.deltaTime;
                }
                SheildGo.SetActive(false);
            }
    #endif 

    #if UNITY_ANDROID

        bool isShielded = CrossPlatformInputManager.GetButtonDown("Shield");
        bool isShieldedUpYet = CrossPlatformInputManager.GetButtonUp("Shield");

        if(isShielded)
        {
            HoldingButtonDown = true;
        }
        if(isShieldedUpYet)
        {
            HoldingButtonDown = false;
        }

        if (HoldingButtonDown && GlobalScript.Shield > 0)
            {
                SheildGo.SetActive(true);
                GlobalScript.shieldisOn = true;
                GlobalScript.Shield -= Time.deltaTime * 10;
            }
            else
            {
                if (GlobalScript.Shield < GlobalScript.myCharacters[GlobalScript.CharacterType].maxShield)
                {
                    GlobalScript.shieldisOn = false;
                    GlobalScript.Shield += Time.deltaTime;
                }
                SheildGo.SetActive(false);
            }
    #endif

    }
}