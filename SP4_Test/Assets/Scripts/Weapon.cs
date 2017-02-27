using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    public Sprite sprite;
    public GameObject projectile;
    //public float projectilespeed;
    public float cooldown;
    public int pelletammo;
    public float ammocout=10;
    public enum  Types
    {
        PISTOL, SHOTGUN , MACHINE
    }
    public Types weapontype;
    void Start()
    {
  
    }


    
  

}
