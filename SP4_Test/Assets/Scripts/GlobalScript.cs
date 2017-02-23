using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalScript : MonoBehaviour {

    public static int CharacterType = 1;
    public static string playerStandingOn;
    //For griffon boss
    public static float GrifLightningCD = 1;
    public static float GrifDefense = 4;
    public static float GrifNormal = 2;
    public static int numberOfGrifHits = 0;
    public static bool flipAttack = false;
    public static bool playerGotHit = false;
    public static int enemyCount = 0;
    public static int howmanytokill = 0;
    public static float GrifHealth;
    public static float Zakhp;
    public static bool Zakenragemode;
    public static float Shield;

    public static bool shieldisOn;

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
        pumpkin.bulletSpeed = 5;
        pumpkin.jumpPower = 1.2F;
        pumpkin.buffDuration = 0.5F;

        robot.description = "From the future";
        robot.name = "EEK";
        robot.speed = 7;
        robot.maxShield = 100;
        robot.jumpPower = 2F;
        robot.bulletSpeed = 10;
        robot.buffDuration = 0.4F;

        santa.description = "He loves children";
        santa.name = "KEK";
        santa.jumpPower = 1.4F;
        santa.speed = 5;
        santa.maxShield = 70;

        santa.bulletSpeed = 3;
        santa.buffDuration = 1.4F;
        knight.description = "Wants to save a princess";
        knight.name = "SEK";
        knight.speed = 10;
        knight.jumpPower = 1.6F;
        knight.bulletSpeed = 6;
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
