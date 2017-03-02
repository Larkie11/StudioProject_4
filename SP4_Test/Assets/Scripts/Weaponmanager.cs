using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Weaponmanager : MonoBehaviour
{
    //[SerializeField]
    //Text text;

    [SerializeField]
    GameObject activeweapon;
    [SerializeField]
    GameObject defaultweapon;
    Weapon wpn;
    float weaponcd;
    [SerializeField]
    float speed = 5;
    GameObject joybutton;
   
    bool noammo = false;

    // Use this for initialization
    void Start()
    {
        wpn = activeweapon.GetComponent<Weapon>();
        GlobalScript.ammocounter = activeweapon.GetComponent<Weapon>().ammocout;
        
        GetComponent<SpriteRenderer>().sprite = wpn.sprite;
        joybutton = GameObject.Find("MobileJoystick");
        weaponcd = wpn.cooldown;

    }

    // Update is called once per frame
    void Update()
    {

       // text.text = "Ammo Count:  " + ammocounter.ToString()+"";

        weaponcd -= Time.deltaTime;
        if (GlobalScript.ammocounter <= 0 && noammo == false)
        {
            noammo = true;
            Changetodefaultweapon();
        }

# if UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.Mouse0) && weaponcd <= 0)
        {
           
            if (wpn.weapontype == Weapon.Types.PISTOL)
            {
                weaponcd = wpn.cooldown;

     
                // Debug.Log("shooting"+ammocounter);

                Vector3 rotation = transform.parent.localScale.x == 1 ? Vector3.zero : Vector3.forward * 1;
                GameObject projectile = (GameObject)Instantiate(wpn.projectile, transform.position + activeweapon.transform.GetChild(0).localPosition *
                    transform.parent.localScale.x, Quaternion.Euler(rotation));
                GlobalScript.ammocounter--;
               
                


            }
        }
        if (Input.GetButton("Fire1") &&  weaponcd <= 0)
        {
             if (wpn.weapontype == Weapon.Types.MACHINE)
            {
                weaponcd = wpn.cooldown;
                // Debug.Log("shooting"+ammocounter);

                Vector3 rotation = transform.parent.localScale.x == 1 ? Vector3.zero : Vector3.forward * 1;
                GameObject projectile = (GameObject)Instantiate(wpn.projectile, transform.position + activeweapon.transform.GetChild(0).localPosition *
                    transform.parent.localScale.x, Quaternion.Euler(rotation));
                GlobalScript.ammocounter--;


            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && weaponcd <= 0)
        {
             if (wpn.weapontype == Weapon.Types.SHOTGUN)
            {
                weaponcd = wpn.cooldown;
                for (int i = 0; i < wpn.pelletammo; i++)
                {
                    var pelletrotation = transform.rotation;
                    pelletrotation.x += Random.Range(-20f, 20f);
                    pelletrotation.z += Random.Range(-20f, 20f);
                    Vector3 rotation = transform.parent.localScale.x == 1 ? Vector3.zero : Vector3.forward * 1;
                    //rotation.x += pelletrotation.x;
                    //rotation.y += pelletrotation.y;
                    rotation.z += pelletrotation.z;
                    GameObject projectile = (GameObject)Instantiate(wpn.projectile, transform.position + activeweapon.transform.GetChild(0).localPosition *
                        transform.parent.localScale.x, Quaternion.Euler(rotation));
                 
                   

                }
                GlobalScript.ammocounter--;
            }
        




        }

#endif

#if UNITY_ANDROID

        
        for (var i = 0; i < Input.touchCount; i++)
        {
            if ((joybutton.GetComponent<Collider2D>().bounds.Contains(Input.GetTouch(i).position)))
            {   
            
            }
            else if (!(joybutton.GetComponent<Collider2D>().bounds.Contains(Input.GetTouch(i).position)))
            {
            
                if (wpn.weapontype == Weapon.Types.PISTOL)
                {
                
                    if (Input.GetTouch(i).phase == TouchPhase.Ended && weaponcd <= 0) 
                  {
              


                        weaponcd = wpn.cooldown;


                        Vector3 rotation = transform.parent.localScale.x == 1 ? Vector3.zero : Vector3.forward * 1;
                        GameObject projectile = (GameObject)Instantiate(wpn.projectile, transform.position + activeweapon.transform.GetChild(0).localPosition *
                            transform.parent.localScale.x, Quaternion.Euler(rotation));
                        ammocounter--;

                    }
                }
                if (wpn.weapontype == Weapon.Types.MACHINE)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Moved && weaponcd <= 0)
                    {



                        weaponcd = wpn.cooldown;


                        Vector3 rotation = transform.parent.localScale.x == 1 ? Vector3.zero : Vector3.forward * 1;
                        GameObject projectile = (GameObject)Instantiate(wpn.projectile, transform.position + activeweapon.transform.GetChild(0).localPosition *
                            transform.parent.localScale.x, Quaternion.Euler(rotation));
                        ammocounter--;

                    }
                }

                if (wpn.weapontype == Weapon.Types.SHOTGUN)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Ended && weaponcd <= 0)
                    {



                        weaponcd = wpn.cooldown;
                        for (int a = 0; a < wpn.pelletammo; a++)
                        {
                            var pelletrotation = transform.rotation;
                            pelletrotation.x += Random.Range(-20f, 20f);
                            pelletrotation.z += Random.Range(-20f, 20f);
                            Vector3 rotation = transform.parent.localScale.x == 1 ? Vector3.zero : Vector3.forward * 1;
                            //rotation.x += pelletrotation.x;
                            //rotation.y += pelletrotation.y;
                            rotation.z += pelletrotation.z;
                            GameObject projectile = (GameObject)Instantiate(wpn.projectile, transform.position + activeweapon.transform.GetChild(0).localPosition *
                                transform.parent.localScale.x, Quaternion.Euler(rotation));
                            ammocounter--;


                        }

                    }
                }



            }
        }


#endif
    }


    void Changetodefaultweapon()
    {

        noammo = false;


        weaponcd = 0;
        Updateweapon(defaultweapon);
        Debug.Log("turningtodefault");
    }
    public void Updateweapon(GameObject weaponhere)
    {
        Debug.Log("newweapon");
        weaponcd = 0;

        activeweapon = weaponhere;
        wpn = activeweapon.GetComponent<Weapon>();

        GetComponent<SpriteRenderer>().sprite = wpn.sprite;
        if(wpn.weapontype==Weapon.Types.SHOTGUN)
        {
            GlobalScript.ammocounter = activeweapon.GetComponent<Weapon>().ammocout/4;
       
        }
        else
        {
            GlobalScript.ammocounter = activeweapon.GetComponent<Weapon>().ammocout;
        }
 
    }
}
