using UnityEngine;
using System.Collections;

public class zakfireskill : MonoBehaviour {

	// Use this for initialization
    float tempfireanimtimer = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        tempfireanimtimer += Time.deltaTime;
        if(tempfireanimtimer>1)
        {
            Destroy(gameObject);
        }
	}
}
