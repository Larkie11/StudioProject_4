using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalScript : MonoBehaviour {

    public static int CharacterType = 0;
    public struct Characters
    {
        public string description;
        public string name;
        public int speed;
        public int shield;
        public float buffDuration;
        public float bulletSpeed;
    }
    public static List<Characters> myCharacters;

    Characters pumpkin;
    Characters robot;
    Characters santa;
    Characters knight;
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
        pumpkin.bulletSpeed = 5;
        pumpkin.buffDuration = 0.5F;
        robot.description = "From the future";
        robot.name = "EEK";
        robot.speed = 1;
        robot.shield = 4;
        robot.bulletSpeed = 10;
        robot.buffDuration = 0.4F;
        santa.description = "He loves children";
        santa.name = "KEK";
        santa.speed = 1;
        santa.shield = 3;
        santa.bulletSpeed = 3;
        santa.buffDuration = 1.4F;
        knight.description = "Wants to save a princess";
        knight.name = "SEK";
        knight.speed = 5;
        knight.bulletSpeed = 6;
        knight.shield = 10;
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
