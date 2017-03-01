using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalScript : MonoBehaviour {

    public static int CharacterType = 0;
    public static string playerStandingOn;
    //For griffon boss
    public static float GrifLightningCD = 1;
    public static float GrifDefense = 2;
    public static float Score = 0;
    public static float GrifNormal = 1;
    public static int numberOfGrifHits = 0;
    public static int fireballcounter;
    public static bool flipAttack = false;
    public static bool playerGotHit = false;
    public static int enemyCount = 0;
    public static int howmanytokill = 0;
    public static float GrifHealth;
    public static float Zakhp;
    public static bool Zakenragemode;
    public static float Shield;
    public static float Volume = 0.5f;
    public static bool shieldisOn;
    public static bool isDead = false;
    public static bool keypickup = false;


    //Kunta Level
    public static int BoxCounter;
    //CrimsonBoss

    public static int CrimsonHealth;
    public static int CrimsonLightingEffect;

    public struct Characters
    {
        public string description;
        public string name;
        public float jumpPower;
        public float speed;
        public float maxShield;
        public float buffDuration;
        public float bulletSpeed;
    }
    public static List<Characters> myCharacters;
    public static GameObject go2;
    Characters pumpkin;
    Characters robot;
    Characters santa;
    Characters knight;
    public static string playerToRender = "";
    public static bool RenderedPlayer = false;
    // Use this for initialization
    void Start () { 
       AddCharacters();
    }
    void AddCharacters()
    {
        myCharacters = new List<Characters>();
        pumpkin.name = "BEK";
        pumpkin.description = "A pumpking character";
        pumpkin.speed = 8;
        pumpkin.maxShield = 60;
        pumpkin.jumpPower = 1700F;
        pumpkin.buffDuration = 0.5F;

        robot.description = "From the future";
        robot.name = "KEK";
        robot.speed = 9;
        robot.maxShield = 100;
        robot.jumpPower = 1750F;
        robot.buffDuration = 0.4F;

        santa.description = "He loves children";
        santa.name = "SEK";
        santa.jumpPower = 1600F;
        santa.speed = 7;
        santa.maxShield = 130;
        santa.buffDuration = 1.4F;

        knight.description = "Wants to save a princess";
        knight.name = "EEK";
        knight.speed = 8;
        knight.jumpPower = 1800F;
        knight.maxShield = 80;
        knight.buffDuration = 1.6F;

        myCharacters.Add(pumpkin);
        myCharacters.Add(knight);
        myCharacters.Add(robot);
        myCharacters.Add(santa);
    }
    // Update is called once per frame
    void Update () { 
    }
}
