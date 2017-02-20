using UnityEngine;
using System.Collections;

public class Weaponmanager : MonoBehaviour {

    public GameObject activeweapon;
    public GameObject defaultweapon;
    Weapon wpn;
    public float speed = 5;

    float ammocounter;
    bool noammo = false;

	// Use this for initialization
	void Start () {
        wpn = activeweapon.GetComponent<Weapon>();
        ammocounter = activeweapon.GetComponent<Weapon>().ammocout;
     
        GetComponent<SpriteRenderer>().sprite = wpn.sprite;

	}
	
	// Update is called once per frame
	void Update () {

        if (ammocounter == 0 && noammo == false)
        {
            noammo = true;
            Changetodefaultweapon();
        }
    	if(Input.GetKeyUp(KeyCode.Mouse0))
    {
       // Debug.Log("shooting"+ammocounter);
         
        Vector3 rotation = transform.parent.localScale.x == 1 ? Vector3.zero : Vector3.forward * 1;
        GameObject projectile = (GameObject)Instantiate(wpn.projectile, transform.position + activeweapon.transform.GetChild(0).localPosition *
            transform.parent.localScale.x, Quaternion.Euler(rotation));
        ammocounter--;
        //Debug.Log(ammocount);
        //projectile.GetComponent<Rigidbody2D>().velocity = transform.parent.localScale.x * Vector2.up * wpn.projectilespeed;
          //  projectile.velocity = transform.TransformDirection (Vector3.forward * speed);

        //Vector2 position = transform.position;
        //position = new Vector2(position.x + speed * Time.deltaTime, position.y);
        //transform.position = position;

        }

        }

    void Changetodefaultweapon()
    {
        
        noammo = false;

        ///change to ak
        ///

        Updateweapon( defaultweapon);
        Debug.Log("turningtodefault");
    }
    public void Updateweapon(GameObject weaponhere)
    {
        Debug.Log("newweapon");
       

        activeweapon = weaponhere;
        wpn = activeweapon.GetComponent<Weapon>();

        GetComponent<SpriteRenderer>().sprite = wpn.sprite;
        ammocounter = activeweapon.GetComponent<Weapon>().ammocout;
	}
}
