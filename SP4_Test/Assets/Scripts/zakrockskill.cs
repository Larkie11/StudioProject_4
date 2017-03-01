using UnityEngine;
using System.Collections;

public class zakrockskill : MonoBehaviour {

	// Use this for initialization
    float temprockanimtimer = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	      temprockanimtimer += Time.deltaTime;
        if(temprockanimtimer>1)
        {
            Destroy(gameObject);
        }
	}
	
}
