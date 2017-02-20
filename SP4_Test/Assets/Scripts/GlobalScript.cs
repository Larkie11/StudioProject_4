using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalScript : MonoBehaviour {

    public static int CharacterType = 0;
    public static string playerStandingOn;
    public static float GrifLightningCD = 1;
    public struct Characters
    {
        public string description;
        public string name;
        public float jumpPower;
        public int speed;
        public int shield;
        public float moveForce;
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
        pumpkin.speed = 1;
        pumpkin.shield = 5;
        pumpkin.moveForce = 1;
        pumpkin.bulletSpeed = 5;
        pumpkin.jumpPower = 1.2F;
        pumpkin.buffDuration = 0.5F;
        robot.description = "From the future";
        robot.name = "EEK";
        robot.speed = 1;
        robot.shield = 4;
        robot.jumpPower = 2F;
        robot.moveForce = 0.6F;
        robot.bulletSpeed = 10;
        robot.buffDuration = 0.4F;
        santa.description = "He loves children";
        santa.name = "KEK";
        santa.jumpPower = 1.4F;
        //santa.speed = 5;
        santa.moveForce = 0.8F;
        santa.shield = 3;
        santa.bulletSpeed = 3;
        santa.buffDuration = 1.4F;
        knight.description = "Wants to save a princess";
        knight.name = "SEK";
        knight.speed = 5;
        knight.jumpPower = 1.6F;
        knight.bulletSpeed = 6;
        knight.shield = 10;
        knight.moveForce = 0.5F;
        knight.buffDuration = 1.6F;
        myCharacters.Add(pumpkin);
        myCharacters.Add(robot);
        myCharacters.Add(knight);
        myCharacters.Add(santa);
    }
    // Update is called once per frame
    void Update () { 
    }
}
