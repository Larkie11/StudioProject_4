using UnityEngine;
using System.Collections;

public class CrimsonAttackEffect : MonoBehaviour {

    private float lifeTime;


	// Use this for initialization
	void Start () {
        lifeTime = 1.6f;
	}
	
	// Update is called once per frame
	void Update () {

        lifeTime -= Time.deltaTime;

	    if(lifeTime < 0)
        {
            Instantiate(Resources.Load("CrimsonBlackLighting"), new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), Quaternion.identity);      
            Destroy(gameObject);
        }

	}
}
