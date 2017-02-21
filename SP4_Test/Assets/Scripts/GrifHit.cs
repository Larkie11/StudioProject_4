using UnityEngine;
using System.Collections;

public class GrifHit : MonoBehaviour {
    float posy = 0;
    bool shot = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if(posy < 5F)
        {
            posy += Time.deltaTime*5F;
        }
        if(posy >= 2.5F && !shot && GlobalScript.numberOfGrifHits<5)
        {
            if(GlobalScript.flipAttack)
            Instantiate(Resources.Load("GrifHit"), new Vector3(transform.position.x - 2F, -15, transform.position.z), Quaternion.identity);
            else
                Instantiate(Resources.Load("GrifHit"), new Vector3(transform.position.x + 2F, -15, transform.position.z), Quaternion.identity);

            GlobalScript.numberOfGrifHits++;
            shot = true;
        }
        if (posy >= 5F)
        {
            Destroy(gameObject);
        }
            transform.localScale = new Vector3(5, posy, transform.position.z);
	}
}
