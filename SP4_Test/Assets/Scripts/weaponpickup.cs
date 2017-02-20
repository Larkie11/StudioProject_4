using UnityEngine;
using System.Collections;
public class weaponpickup : MonoBehaviour {


    public GameObject[] weapons;
    public GameObject weaponhere;
	// Use this for initialization
	void Start () {
        weaponhere = weapons[Random.Range(0, weapons.Length)];
        GetComponent<SpriteRenderer>().sprite = weaponhere.GetComponent<SpriteRenderer>().sprite;


	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.Find("weaponslot").GetComponent<Weaponmanager>().Updateweapon(weaponhere);
            //Destroy(gameObject );
            Debug.Log("puckup");
        }
            
    }
}
